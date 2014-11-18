namespace TeamTaskboard.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.ViewModels.Project;
    using TeamTaskboard.Web.InputModels.Project;

    [Authorize]
    public class ProjectsController : BaseController
    {
        public ProjectsController(ITaskboardData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var teamId = this.CurrentUser.TeamId;
            if (teamId == null)
            {
                return RedirectToAction("Index", "Team");
            }

            ViewBag.TeamName = this.CurrentUser.Team.Name;

            var projects = this.Data.Projects.GetAll()
                .Where(p => p.TeamId == teamId)
                .Project()
                .To<ProjectViewModel>();

            return View(projects);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var project = this.Data.Projects.GetAll().Where(p => p.ProjectId == id);
            if (project == null)
            {
                return View("NotFound");
            }

            var projectModel = project.Project().To<ProjectViewModel>().FirstOrDefault();

            return View(projectModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProjectInputModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectInputModel model)
        {
            int? teamId = this.CurrentUser.TeamId;
            if (teamId == null)
            {
                ModelState.AddModelError(string.Empty, "You must be part of a team to create a project.");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var project = Mapper.Map<Project>(model);
            project.TeamId = (int)teamId;
            this.Data.Projects.Add(project);
            this.Data.SaveChanges();

            return RedirectToAction("Index", "Team");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var project = this.Data.Projects.GetAll().Where(p => p.ProjectId == id).Include(p => p.Tasks).FirstOrDefault();
            if (project == null)
            {
                return View("NotFound");
            }

            foreach (var task in project.Tasks.ToList())
            {
                this.Data.Tasks.Delete(task);
            }

            this.Data.Projects.Delete(project);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var project = this.Data.Projects.GetById(id);
            if (project == null)
            {
                return View("NotFound");
            }

            var model = Mapper.Map<ProjectInputModel>(project);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProjectInputModel model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return View(model);
            }

            var entity = this.Data.Projects.GetById(model.ProjectId);
            entity.Name = model.Name;
            entity.Description = model.Description;
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}