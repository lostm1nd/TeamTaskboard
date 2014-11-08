namespace TeamTaskboard.Web.Controllers
{
    using System.Web.Mvc;
    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.InputModels;

    [Authorize]
    public class TasksController : BaseController
    {
        public TasksController(ITaskboardData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTask(TaskInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TeamTask task = new TeamTask
            {
                Name = model.Name,
                Description = model.Description,
                DueDate = model.DueDate
            };

            this.Data.TeamTasks.Add(task);
            task.Reporter = this.CurrentUser;
            task.Team = this.CurrentTeam;

            this.Data.SaveChanges();

            return RedirectToAction("Index", "Team");
        }
    }
}