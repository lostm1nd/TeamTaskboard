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

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
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
