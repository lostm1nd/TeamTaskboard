namespace TeamTaskboard.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Web.Areas.Administration.ViewModels;

    public class TeamsController : AdminBaseController
    {
        public TeamsController(ITaskboardData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var teams = this.Data.Teams.GetAll()
                .Project()
                .To<TeamViewModel>()
                .ToDataSourceResult(request);

            return Json(teams);
        }
    }
}