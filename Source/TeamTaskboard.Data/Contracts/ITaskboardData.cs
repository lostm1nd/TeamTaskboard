namespace TeamTaskboard.Data.Contracts
{
    using System.Data.Entity;
    using TeamTaskboard.Models;

    public interface ITaskboardData
    {
        DbContext Context { get; }

        IRepository<TaskboardUser> Users { get; }

        IRepository<Team> Teams { get; }

        IRepository<Project> Projects { get; }

        IRepository<TeamTask> Tasks { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Avatar> Avatars { get; }

        int SaveChanges();
    }
}
