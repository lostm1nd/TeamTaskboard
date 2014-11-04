namespace TeamTaskboard.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using TeamTaskboard.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskboardDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "TeamTaskboard.Data.TaskboardDbContext";
        }

        protected override void Seed(TaskboardDbContext context)
        {
        }
    }
}
