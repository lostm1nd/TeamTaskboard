namespace TeamTaskboard.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.ViewModels.Task;

    [Authorize]
    public class TasksController : BaseController
    {
        public TasksController(ITaskboardData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var task = this.Data.Tasks.GetById(id);
            if (task == null)
            {
                return View("NotFound");
            }

            var taskModel = Mapper.Map<ExtendedTaskViewModel>(this.Data.Tasks.GetById(id));

            return View(taskModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var projects = this.CurrentUser.Team.Projects.Select(p => new { Id = p.ProjectId, Name = p.Name});
            ViewBag.ProjectList = new SelectList(projects, "Id", "Name");

            return View(new CreateTaskViewModel { DueDate = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TeamTask task = Mapper.Map<TeamTask>(model);
            task.Reporter = this.CurrentUser;
            this.Data.Tasks.Add(task);
            this.Data.SaveChanges();

            return RedirectToAction("Index", "Team");
        }

        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            var taskModel = Mapper.Map<ExtendedTaskViewModel>(this.Data.Tasks.GetById(id));

            return PartialView("_ChangeStatusPartial", taskModel);
        }
    }
}