namespace TeamTaskboard.Web.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;

    using TeamTaskboard.Common;
    using TeamTaskboard.Data.Contracts;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public abstract class AdminBaseController : Controller
    {
        public AdminBaseController(ITaskboardData data)
        {
            this.Data = data;
        }

        protected ITaskboardData Data { get; set; }
    }
}