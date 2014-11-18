namespace TeamTaskboard.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using TeamTaskboard.Models;
    using TeamTaskboard.Common;

    public sealed class Configuration : DbMigrationsConfiguration<TaskboardDbContext>
    {
        private UserManager<TaskboardUser> userManager;
        private RandomGenerator randomizer;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TaskboardDbContext context)
        {
            this.userManager = new UserManager<TaskboardUser>(new UserStore<TaskboardUser>(context));
            this.randomizer = new RandomGenerator();

            this.SeedRoles(context);

            this.SeedUsers(context);

            this.SeedTeams(context);

            this.SeedProjects(context);

            this.SeedTasks(context);
        }


        private void SeedRoles(TaskboardDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.AdminRole));
            context.SaveChanges();
        }

        private void SeedUsers(TaskboardDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var admin = new TaskboardUser
            {
                Email = "admin@admin.com",
                UserName = GlobalConstants.AdminRole
            };

            this.userManager.Create(admin, "tainaparola");
            this.userManager.AddToRole(admin.Id, GlobalConstants.AdminRole);

            for (int i = 0; i < 100; i++)
            {                
                var user = new TaskboardUser
                {
                    Email = "peter" + i + "@peter.com",
                    UserName = "Peter" + i
                };

                this.userManager.Create(user, "123456");
            }
        }

        private void SeedTeams(TaskboardDbContext context)
        {
            if (context.Teams.Any())
            {
                return;
            }

            var users = context.Users.Where(u => u.UserName != GlobalConstants.AdminRole).ToList();

            for (int i = 0; i < 15; i++)
            {
                var team = new Team
                {
                    Name = "Team " + i,
                    Description = "Description for team " + i
                };

                while (team.Members.Count < 4)
                {
                    var randomUser = users[this.randomizer.GetRandomNumber(0, users.Count)];
                    if (randomUser.TeamId == null)
                    {
                        team.Members.Add(randomUser);
                    }
                }

                context.Teams.Add(team);
                context.SaveChanges();
            }
        }
        private void SeedProjects(TaskboardDbContext context)
        {
            if (context.Projects.Any())
            {
                return;
            }

            var teams = context.Teams.Select(t => t.TeamId).ToList();
            foreach (var teamId in teams)
            {
                context.Projects.AddOrUpdate(p => p.ProjectId,
                    new Project
                    {
                        Name = "Porject uno",
                        Description = "Project uno por equipo " + teamId,
                        TeamId = teamId
                    },
                    new Project
                    {
                        Name = "Porject dos",
                        Description = "Project dos por equipo " + teamId,
                        TeamId = teamId
                    },
                    new Project
                    {
                        Name = "Porject tres",
                        Description = "Project tres por equipo " + teamId,
                        TeamId = teamId
                    });
            }
        }

        private void SeedTasks(TaskboardDbContext context)
        {
            if (context.Tasks.Any())
            {
                return;
            }

            var projects = context.Projects.Select(p => p.ProjectId).ToList();
            foreach (var projectId in projects)
            {
                context.Tasks.AddOrUpdate(t => t.TeamTaskId,
                    new TeamTask
                    {
                        Name = "Sample task 1",
                        Description = "Sample desscription for task 1",
                        DueDate = DateTime.Now.AddDays(10),
                        ProjectId = projectId,
                        Status = Status.InProgress
                    },
                    new TeamTask
                    {
                        Name = "Sample task 2",
                        Description = "Sample desscription for task 2",
                        DueDate = DateTime.Now.AddDays(5),
                        ProjectId = projectId,
                        Status = Status.InReview
                    },
                    new TeamTask
                    {
                        Name = "Sample task 3",
                        Description = "Sample desscription for task 3",
                        DueDate = DateTime.Now.AddDays(20),
                        ProjectId = projectId,
                        Status = Status.Blocked
                    });
            }
        }
    }
}
