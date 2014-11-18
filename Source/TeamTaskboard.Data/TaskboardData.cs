namespace TeamTaskboard.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using TeamTaskboard.Data.Contracts;
    using TeamTaskboard.Models;

    public class TaskboardData : ITaskboardData
    {
        private readonly DbContext dbContext;
        private readonly IDictionary<Type, object> repositories;

        public TaskboardData()
            : this(new TaskboardDbContext())
        {
        }

        public TaskboardData(DbContext context)
        {
            this.dbContext = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public DbContext Context
        {
            get { return this.dbContext; }
        }

        public IRepository<TaskboardUser> Users
        {
            get { return this.GetRepository<TaskboardUser>(); }
        }

        public IRepository<Team> Teams
        {
            get { return this.GetRepository<Team>(); }
        }

        public IRepository<Project> Projects
        {
            get { return this.GetRepository<Project>(); }
        }

        public IRepository<TeamTask> Tasks
        {
            get { return this.GetRepository<TeamTask>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), this.dbContext);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
