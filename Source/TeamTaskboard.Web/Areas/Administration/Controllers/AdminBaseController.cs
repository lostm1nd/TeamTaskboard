namespace TeamTaskboard.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using TeamTaskboard.Data.Contracts;

    //[Authorize(Roles = "Aministrator")]
    public abstract class AdminBaseController : Controller
    {
        public AdminBaseController(ITaskboardData data)
        {
            this.Data = data;
        }

        protected ITaskboardData Data { get; set; }
    }
}