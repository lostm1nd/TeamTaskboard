namespace TeamTaskboard.Web.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;
    using TeamTaskboard.Data.Contracts;

    //[Authorize(Roles = "Administrator")]
    public abstract class AdminBaseController : Controller
    {
        public AdminBaseController(ITaskboardData data)
        {
            this.Data = data;
        }

        protected ITaskboardData Data { get; set; }
    }
}