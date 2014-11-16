namespace TeamTaskboard.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using TeamTaskboard.Data.Contracts;

    public class HomeController : AdminBaseController
    {
        public HomeController(ITaskboardData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}