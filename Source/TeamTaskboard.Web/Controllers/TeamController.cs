namespace TeamTaskboard.Web.Controllers
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.InputModels.Team;
    using TeamTaskboard.Web.ViewModels.Team;
    using TeamTaskboard.Web.ViewModels.Task;
    using TeamTaskboard.Web.Helpers;

    [Authorize]
    public class TeamController : BaseController
    {
        private TaskHelper taskHelper;

        public TeamController(ITaskboardData data)
            : base(data)
        {
            this.taskHelper = new TaskHelper(data);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var team = this.CurrentUser.Team;
            if (team == null)
            {
                return View("NoTeam");
            }
            else
            {
                var teamModel = Mapper.Map<ExtendedTeamViewModel>(team);
                ViewBag.Tasks = this.taskHelper.GetMappedTasksForTeam<TaskViewModel>(team.TeamId);
                return View("TeamInfo", teamModel);
            }
        }

        [HttpGet]
        public ActionResult JoinTeam()
        {
            return PartialView("_JoinTeamPartial", this.Data.Teams.GetAll().Project().To<TeamViewModel>());
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

        [HttpGet]
        public ActionResult LeaveTeam()
        {
            if (this.CurrentUser == null || this.CurrentUser.TeamId == null)
            {
                return RedirectToAction("Index");
            }

            var tasks = this.taskHelper.GetTasksForTeam(this.CurrentUser.TeamId.Value);
            foreach (var task in tasks)
            {
                if (task.Processor != null && task.Processor.Id == this.CurrentUser.Id)
                {
                    task.Processor = null;
                }
            }

            this.CurrentUser.TeamId = null;
            this.CurrentUser.Team = null;
            this.Data.SaveChanges();

            return RedirectToAction("Index");
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
    }
}