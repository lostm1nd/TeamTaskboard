namespace TeamTaskboard.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using TeamTaskboard.Data.Contracts;

    public class ImagesController : BaseController
    {
        public ImagesController(ITaskboardData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult GetUserAvatar(string id)
        {
            var avatar = this.Data.Users.GetById(id).Avatar;
            if (avatar == null)
            {
                return File("~/Content/images/default-avatar.jpg", "image/jpeg");
            }

            return File(avatar.Data, avatar.ContentType);
        }
    }
}