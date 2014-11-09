namespace TeamTaskboard.Web.Controllers
{
    using System.Threading;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;

    public abstract class BaseController : Controller
    {
        public BaseController(ITaskboardData data)
        {
            this.Data = data;
            this.CurrentUser = data.Users.GetById(Thread.CurrentPrincipal.Identity.GetUserId());
        }

        public ITaskboardData Data { get; private set; }

        public TaskboardUser CurrentUser { get; private set; }
    }
}