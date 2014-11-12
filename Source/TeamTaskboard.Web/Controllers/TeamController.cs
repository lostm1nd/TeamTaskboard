﻿namespace TeamTaskboard.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.InputModels.Team;
    using TeamTaskboard.Web.ViewModels.Team;

    [Authorize]
    public class TeamController : BaseController
    {
        public TeamController(ITaskboardData data)
            : base(data)
        {
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