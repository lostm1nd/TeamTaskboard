namespace TeamTaskboard.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Areas.Administration.ViewModels;
    using TeamTaskboard.Web.Areas.Administration.Controllers.Base;

    public class TeamsController : KendoGridController
    {
        public TeamsController(ITaskboardData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, TeamViewModel model)
        {
            var entity = base.Create<Team>(model);
            if (entity != null)
            {
                model.TeamId = entity.TeamId;
            }

            return this.GridOperation(request, model);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, TeamViewModel model)
        {
            base.Update<Team, TeamViewModel>(model, model.TeamId);

            return this.GridOperation(request, model);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, TeamViewModel model)
        {
            var team = this.GetById<Team>(model.TeamId);
            foreach (var projectId in team.Projects.Select(p => p.ProjectId).ToList())
            {
                var taskIds = this.Data.Tasks.GetAll().Where(t => t.ProjectId == projectId).Select(t => t.TeamTaskId).ToList();
                foreach (var taskId in taskIds)
                {
                    this.Data.Tasks.Delete(taskId);
                }

                this.Data.Projects.Delete(projectId);
                this.Data.SaveChanges();
            }

            var teamMembers = team.Members.ToList();
            foreach (var member in teamMembers)
            {
                member.TeamId = null;
            }

            this.Data.SaveChanges();

            this.Data.Teams.Delete(model.TeamId);
            this.Data.SaveChanges();

            return this.GridOperation(request, model);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Teams.GetAll().Project().To<TeamViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Teams.GetById(id) as T;
        }
    }
}