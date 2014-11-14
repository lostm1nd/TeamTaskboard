namespace TeamTaskboard.Web.Controllers
{
    using System.Web.Mvc;
    using TeamTaskboard.Data.Contracts;

    [Authorize]
    public class CommentsController : BaseController
    {
        public CommentsController(ITaskboardData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int taskId)
        {
            ViewBag.TaskId = taskId;
            return PartialView("_CreateComment");
        }
    }
}