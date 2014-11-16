namespace TeamTaskboard.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using TeamTaskboard.Data.Contracts;

    public class TeamsController : AdminBaseController
    {
        public TeamsController(ITaskboardData data)
            : base(data)
        {
        }

        public ActionResult Manage()
        {
            return View();
        }
    }
}