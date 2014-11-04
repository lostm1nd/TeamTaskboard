namespace TeamTaskboard.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using TeamTaskboard.Data.Migrations;
    using TeamTaskboard.Models;

    public class TaskboardDbContext : IdentityDbContext<User>
    {
        public TaskboardDbContext()
            : base("TaskboardConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TaskboardDbContext, Configuration>());
        }

        public static TaskboardDbContext Create()
        {
            return new TaskboardDbContext();
        }
    }
}
