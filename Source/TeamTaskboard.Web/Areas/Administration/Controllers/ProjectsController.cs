namespace TeamTaskboard.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using TeamTaskboard.Data.Contracts;
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