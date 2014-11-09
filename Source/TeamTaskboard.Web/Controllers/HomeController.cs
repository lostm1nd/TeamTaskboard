namespace TeamTaskboard.Web.Controllers
{
    using System.Linq;
    using System.Web.Helpers;
    using System.Web.Mvc;

    using TeamTaskboard.Data.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(ITaskboardData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            ViewBag.UsersCount = this.Data.Users.GetAll().Count();
            ViewBag.TeamsCount = this.Data.Teams.GetAll().Count();
            ViewBag.ProjectsCount = this.Data.Projects.GetAll().Count();
            return View();
        }

        public ActionResult GetTasksChart()
        {
            var tasksChart = new Chart(width: 300, height: 300)
                .AddTitle("Total tasks: " + 52)
                .AddSeries(
                    chartType: "Pie",
                    xValue: new[] { "Done", "Not done", "In Progress", "Blocked" },
                    yValues: new[] { "2", "7", "5", "3" });

            return File(tasksChart.ToWebImage().GetBytes(), "image/jpeg");
        }
    }
}