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

    [Authorize]
    public class CommentsController : BaseController
    {
        public CommentsController(ITaskboardData data)
            : base(data)
        {
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
            model.PostedBy = this.CurrentUser.UserName;
            model.PostedOn = DateTime.Now;

            Comment comment = Mapper.Map<Comment>(model);
            comment.TeamTaskId = model.TaskId;
            this.Data.Comments.Add(comment);
            this.Data.SaveChanges();

            var commentsViewModel = this.Data.Comments.GetAll()
                .Where(c => c.TeamTaskId == model.TaskId)
                .Project().To<CommentViewModel>();

            return PartialView("_ShowCommentsPartial", commentsViewModel);
        }
    }
}