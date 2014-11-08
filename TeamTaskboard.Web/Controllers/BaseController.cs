namespace TeamTaskboard.Web.Controllers
{
    using System.Threading;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using TeamTaskboard.Data;
    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;

    public abstract class BaseController : Controller
    {
        public BaseController()
            : this(new TaskboardData(new TaskboardDbContext()))
        {
        }

        public BaseController(ITaskboardData data)
        {
            this.Data = data;
            this.CurrentUser = data.Users.GetById(Thread.CurrentPrincipal.Identity.GetUserId());
        }

        public ITaskboardData Data { get; private set; }

        public User CurrentUser { get; private set; }
    }
}