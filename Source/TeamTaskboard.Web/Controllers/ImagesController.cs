namespace TeamTaskboard.Web.Controllers
{
    using System.IO;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;

    [Authorize]
    public class ImagesController : BaseController
    {
        public ImagesController(ITaskboardData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult GetUserAvatar(string id)
        {
            var avatar = this.CurrentUser.Avatar;
            if (avatar == null)
            {
                return File("~/Content/images/default-avatar.jpg", "image/jpeg");
            }

            return File(avatar.Data, avatar.ContentType);
        }

        [HttpPost]
        public ActionResult UpdateProfileImage(HttpPostedFileBase profileImage)
        {
            var avatarId = this.CurrentUser.AvatarId;
            if (profileImage != null)
            {
                if (avatarId != null)
                {
                    this.CurrentUser.AvatarId = null;
                    this.Data.Avatars.Delete(avatarId.Value);
                    this.Data.SaveChanges();
                }

                using (MemoryStream target = new MemoryStream())
                {
                    profileImage.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();
                    this.CurrentUser.Avatar = new Avatar
                    {
                        Data = data,
                        ContentType = profileImage.ContentType
                    };
                }

                this.Data.SaveChanges();
            }

            return RedirectToAction("Index", "Manage");
        }
    }
}