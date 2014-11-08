namespace TeamTaskboard.Web.Controllers
{
    using System.Web.Mvc;
    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.InputModels;

    public class StatusesController : BaseController
    {
        public StatusesController(ITaskboardData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateStatus()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStatus(StatusInputModel model)
        {
            Status status = new Status
            {
                Name = model.Name
            };
            status.Teams.Add(this.CurrentUser.Team);
            this.Data.Statuses.Add(status);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}