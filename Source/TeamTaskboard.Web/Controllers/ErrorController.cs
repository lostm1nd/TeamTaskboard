namespace TeamTaskboard.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("Error");
        }

        [HttpGet]
        public ActionResult NotFound()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ServerError()
        {
            return View();
        }
    }
}