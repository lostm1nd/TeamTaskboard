namespace TeamTaskboard.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;


    public class ProfileController : Controller
    {

        public ActionResult ChangePassword()
        {
            return PartialView("_ChangePasswordPartial");
        }

        public ActionResult SetPassword()
        {
            return PartialView("_SetPasswordPartial");
        }
    }
}