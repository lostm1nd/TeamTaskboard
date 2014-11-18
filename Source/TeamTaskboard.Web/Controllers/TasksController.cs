namespace TeamTaskboard.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.InputModels.Task;
    using TeamTaskboard.Web.ViewModels.Task;
    using TeamTaskboard.Web.Helpers;

    [Authorize]
    public class TasksController : BaseController
    {
        private TaskHelper taskHelper;

        public TasksController(ITaskboardData data)
            : base(data)
        {
            this.taskHelper = new TaskHelper(data);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var teamId = this.CurrentUser.TeamId;
            if (teamId == null)
            {
                return RedirectToAction("Index", "Team");
            }

            ViewBag.TeamName = this.CurrentUser.Team.Name;
            var tasks = this.taskHelper.GetMappedTasksForTeam<ExtendedTaskViewModel>(teamId.Value);

            return View(tasks);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var task = this.Data.Tasks.GetById(id);
            if (task == null)
            {
                return View("NotFound");
            }

            var taskModel = Mapper.Map<ExtendedTaskViewModel>(task);

            return View(taskModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var projects = this.CurrentUser.Team.Projects.Select(p => new { Id = p.ProjectId, Name = p.Name});
            ViewBag.ProjectList = new SelectList(projects, "Id", "Name");

            return View(new CreateTaskInputModel { DueDate = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTaskInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TeamTask task = Mapper.Map<TeamTask>(model);
            task.Reporter = this.CurrentUser;
            this.Data.Tasks.Add(task);
            this.Data.SaveChanges();

            return RedirectToAction("Index", "Team");
        }

        [HttpGet]
        public ActionResult Assign(int id)
        {
            var task = this.Data.Tasks.GetById(id);
            task.Processor = this.CurrentUser;
            this.Data.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            var taskModel = Mapper.Map<ExtendedTaskViewModel>(this.Data.Tasks.GetById(id));

            return PartialView("_ChangeStatusPartial", taskModel);
        }

        [HttpPost]
        public ActionResult ChangeStatus(int id, int status)
        {
            var task =this.Data.Tasks.GetById(id);
            task.Status = (Status)status;
            this.Data.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var task = this.Data.Tasks.GetById(id);
            if (task == null)
            {
                return View("NotFound");
            }

            var model = Mapper.Map<CreateTaskInputModel>(task);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CreateTaskInputModel model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return View(model);
            }

            var entity = this.Data.Tasks.GetById(model.TeamTaskId);
            entity.Name = model.Name;
            entity.Description = model.Description;
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var task = this.Data.Tasks.GetById(id);
            if (task == null)
            {
                return View("NotFound");
            }

            this.Data.Tasks.Delete(task);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}