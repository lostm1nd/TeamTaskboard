﻿namespace TeamTaskboard.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using TeamTaskboard.Data.Contracts;
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

        protected override IEnumerable GetData()
        {
            return this.Data.Teams.GetAll().Project().To<TeamViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Projects.GetById(id) as T;
        }
    }
}