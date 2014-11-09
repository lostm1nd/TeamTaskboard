namespace TeamTaskboard.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using TeamTaskboard.Data.Migrations;
    using TeamTaskboard.Models;

    public class TaskboardDbContext : IdentityDbContext<TaskboardUser>
    {
        public TaskboardDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TaskboardDbContext, Configuration>());
        }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Project> Projects { get; set; }

        public IDbSet<TeamTask> Tasks { get; set; }

        public static TaskboardDbContext Create()
        {
            return new TaskboardDbContext();
        }
    }
}
