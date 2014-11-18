namespace TeamTaskboard.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Areas.Administration.ViewModels;
    using TeamTaskboard.Web.Areas.Administration.Controllers.Base;

    public class ProjectsController : KendoGridController
    {
        public ProjectsController(ITaskboardData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ProjectViewModel model)
        {
            base.Update<Project, ProjectViewModel>(model, model.ProjectId);

            return this.GridOperation(request, model);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ProjectViewModel model)
        {
            base.Destroy<Project>(model.ProjectId);

            return this.GridOperation(request, model);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Projects.GetAll().Project().To<ProjectViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Projects.GetById(id) as T;
        }
    }
}