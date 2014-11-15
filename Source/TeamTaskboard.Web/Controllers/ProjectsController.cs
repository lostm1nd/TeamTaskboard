namespace TeamTaskboard.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.ViewModels.Project;

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
            return View(new CreateProjectViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProjectViewModel model)
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
    }
}