namespace TeamTaskboard.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Helpers;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Json;
    using TeamTaskboard.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        public HomeController(ITaskboardData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 5 * 60)]
        public ActionResult GetStatistics()
        {
            ViewBag.UsersCount = this.Data.Users.GetAll().Count();
            ViewBag.TeamsCount = this.Data.Teams.GetAll().Count();
            ViewBag.ProjectsCount = this.Data.Projects.GetAll().Count();
            return PartialView("_StatisticsPartial");
        }

        [OutputCache(Duration = 5 * 60)]
        public ActionResult GetTasks()
        {
            var tasks = this.Data.Tasks.GetAll().ToList();
            TaskJsonModel[] data = new TaskJsonModel[]
            {
                new TaskJsonModel
                {
                    Label = "Not started",
                    Value = tasks.Where(t => t.Status == Status.NotStarted).Count(),
                    Color = "#F7464A",
                    Highlight = "#FF5A5E"
                },
                new TaskJsonModel
                {
                    Label = "In progress",
                    Value = tasks.Where(t => t.Status == Status.InProgress).Count(),
                    Color = "#46BFBD",
                    Highlight = "#5AD3D1"
                },
                new TaskJsonModel
                {
                    Label = "In Review",
                    Value = tasks.Where(t => t.Status == Status.InReview).Count(),
                    Color = "#FDB45C",
                    Highlight = "#FFC870"
                },
                new TaskJsonModel
                {
                    Label = "Blocked",
                    Value = tasks.Where(t => t.Status == Status.Blocked).Count(),
                    Color = "#B48EAD",
                    Highlight = "#C69CBE"
                },
                new TaskJsonModel
                {
                    Label = "Blocked",
                    Value = tasks.Where(t => t.Status == Status.Done).Count(),
                    Color = "#949FB1",
                    Highlight = "#A8B3C5"
                }
            };

            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new LowercaseContractResolver();
            var json = JsonConvert.SerializeObject(data, settings);

            return Content(json, "application/json");
        }
    }
}