namespace TeamTaskboard.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using TeamTaskboard.Data.Contracts;
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
            return View();
        }
    }
}