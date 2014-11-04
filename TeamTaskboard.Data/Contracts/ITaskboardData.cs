namespace TeamTaskboard.Data.Contracts
{
    using TeamTaskboard.Models;

    public interface ITaskboardData
    {
        IRepository<User> Users { get; }

        int SaveChanges();
    }
}
