namespace TeamTaskboard.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.InputModels.Comment;
    using TeamTaskboard.Web.ViewModels.Comment;
    using TeamTaskboard.Web.Infrastructure.Sanitize;

    [Authorize]
    public class CommentsController : BaseController
    {
        private ISanitizer htmlSanitizer;

        public CommentsController(ITaskboardData data, ISanitizer sanitizer)
            : base(data)
        {
            this.htmlSanitizer = sanitizer;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int taskId)
        {
            return PartialView("_CreateCommentPartial", new CommentInputModel { TaskId = taskId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentInputModel model)
        {
            Comment comment = new Comment 
            {
                Content = this.htmlSanitizer.Sanitize(model.Content),
                PostedBy = this.CurrentUser.UserName,
                PostedOn = DateTime.Now,
                TeamTaskId = model.TaskId
            };

            this.Data.Comments.Add(comment);
            this.Data.SaveChanges();

            var commentViewModel = Mapper.Map<CommentViewModel>(comment);

            return PartialView("_CommentPartial", commentViewModel);
        }
    }
}