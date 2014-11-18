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

    public class TasksController : KendoGridController
    {
        public TasksController(ITaskboardData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Tasks.GetAll().Project().To<TaskViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Tasks.GetById(id) as T;
        }
    }
}