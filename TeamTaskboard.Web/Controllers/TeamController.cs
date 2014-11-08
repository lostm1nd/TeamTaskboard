namespace TeamTaskboard.Web.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Models;
    using TeamTaskboard.Web.ViewModels;
    using TeamTaskboard.Web.InputModels;

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
            return PartialView("_JoinTeamPartial", this.Data.Teams.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            return PartialView("_CreateTeamPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTeam(TeamInputModel model)
        {
            Team dbTeam = new Team
            {
                Name = model.Name,
                Description = model.Description
            };
            this.Data.Teams.Add(dbTeam);
            dbTeam.Members.Add(this.CurrentUser);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult LeaveTeam()
        {
            this.CurrentUser.TeamId = null;
            this.CurrentUser.Team = null;
            this.CurrentUser.ProcessedTasks = null;
            this.CurrentUser.ReportertedTasks = null;
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}