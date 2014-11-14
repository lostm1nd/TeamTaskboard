namespace TeamTaskboard.Web.ViewModels.Task
{
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;

    public class TaskViewModel : IMapFrom<TeamTask>
    {
        public int TaskId { get; set; }

        public string Name { get; set; }
    }
}