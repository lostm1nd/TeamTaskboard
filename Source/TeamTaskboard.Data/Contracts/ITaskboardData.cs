namespace TeamTaskboard.Data.Contracts
{
    using TeamTaskboard.Models;

    public interface ITaskboardData
    {
        IRepository<TaskboardUser> Users { get; }

        IRepository<Team> Teams { get; }

        IRepository<Project> Projects { get; }

        IRepository<TeamTask> Tasks { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
