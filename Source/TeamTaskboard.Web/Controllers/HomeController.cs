namespace TeamTaskboard.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Helpers;
    using System.Web.Mvc;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;

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
            return PartialView("_GetStatisticsPartial");
        }

        public ActionResult GetTasksChart()
        {
            if (HttpContext.Cache["TasksStats"] == null)
            {
                var tasks = this.Data.Tasks.GetAll().ToList();
                int[] stats = 
                {
                    10, //tasks.Where(t => t.Status == Status.NotStarted).Count(),
                    12, //tasks.Where(t => t.Status == Status.InProgress).Count(),
                    16, //tasks.Where(t => t.Status == Status.InReview).Count(),
                    13, //tasks.Where(t => t.Status == Status.Blocked).Count(),
                    14 //tasks.Where(t => t.Status == Status.Done).Count()
                };

                HttpContext.Cache.Insert(
                    "TasksStats",
                    stats,
                    null,
                    DateTime.Now.AddMinutes(5),
                    TimeSpan.Zero);
            }

            int totalTasksCount = 0;
            foreach (var taskCount in (int[])HttpContext.Cache["TasksStats"])
            {
                totalTasksCount += taskCount;
            }

            var tasksChart = new Chart(width: 300, height: 300)
                .AddTitle("Total tasks created: " + totalTasksCount)
                .AddSeries(
                    chartType: "Pie",
                    xValue: new[] { "Not started", "In Progress", "In Review", "Blocked", "Done" },
                    yValues: (int[])HttpContext.Cache["TasksStats"]);

            return File(tasksChart.ToWebImage().GetBytes(), "image/jpeg");
        }
    }
}