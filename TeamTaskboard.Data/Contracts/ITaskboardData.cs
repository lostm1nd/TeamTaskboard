namespace TeamTaskboard.Data.Contracts
{
    using TeamTaskboard.Models;

    public interface ITaskboardData
    {
        IRepository<User> Users { get; }

        IRepository<Team> Teams { get; }

        IRepository<TeamTask> TeamTasks { get; }

        IRepository<Status> Statuses { get; }

        int SaveChanges();
    }
}
