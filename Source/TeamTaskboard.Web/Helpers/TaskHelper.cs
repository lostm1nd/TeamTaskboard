namespace TeamTaskboard.Web.Helpers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using AutoMapper;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Web.ViewModels.Task;
    using TeamTaskboard.Models;

    public class TaskHelper
    {
        private ITaskboardData data;

        public TaskHelper(ITaskboardData data)
        {
            this.data = data;
        }

        public List<TeamTask> GetTasksForTeam(int teamId)
        {
            var projects = this.data.Projects.GetAll().Where(p => p.TeamId == teamId).Include(p => p.Tasks).ToList();
            var allTasks = new List<TeamTask>();
            foreach (var project in projects)
            {
                foreach (var task in project.Tasks)
                {
                    allTasks.Add(task);
                }
            }

            return allTasks;
        }

        public List<T> GetMappedTasksForTeam<T>(int teamId)
        {
            var projects = this.data.Projects.GetAll().Where(p => p.TeamId == teamId).Include(p => p.Tasks).ToList();
            var allTasks = new List<T>();
            foreach (var project in projects)
            {
                foreach (var task in project.Tasks)
                {
                    allTasks.Add(Mapper.Map<T>(task));
                }
            }

            return allTasks;
        }
    }
}