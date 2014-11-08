﻿namespace TeamTaskboard.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.InputModels;

    [Authorize]
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
            Status status = this.CurrentTeam.Statuses.FirstOrDefault(s => s.Name == model.Name);
            if (status != null)
            {
                ModelState.AddModelError(string.Empty, "Status is already defined for the team.");
                return View(model);
            }

            status = new Status { Name = model.Name };
            this.Data.Statuses.Add(status);
            status.Team = this.CurrentTeam;            
            this.Data.SaveChanges();

            return RedirectToAction("Index", "Team");
        }
    }
}