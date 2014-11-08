namespace TeamTaskboard.Web.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Models;

    [Authorize]
    public class TeamController : BaseController
    {
        public TeamController()
            : base()
        {
        }

        public ActionResult Index()
        {
            return View(this.CurrentUser);
        }

        [HttpGet]
        public ActionResult JoinTeam()
        {
            return PartialView("_JoinPartial", this.Data.Teams.GetAll());
        }

        [HttpPost]
        public ActionResult JoinTeam(int? teamId)
        {
            if (teamId == null)
            {
                return RedirectToAction("Index");
            }

            var team = this.Data.Teams.GetById(teamId);
            team.Members.Add(this.CurrentUser);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateTeam()
        {
            return PartialView("_CreatePartial");
        }

        [HttpPost]
        public ActionResult CreateTeam(Team team)
        {
            this.Data.Teams.Add(team);
            team.Members.Add(this.CurrentUser);
            this.Data.SaveChanges();

            return Redirect("~/Team/Index");
        }
    }
}