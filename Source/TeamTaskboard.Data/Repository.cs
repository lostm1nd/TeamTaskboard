namespace TeamTaskboard.Data
{
    using System.Data.Entity;
    using System.Linq;

    using TeamTaskboard.Data.Contracts;

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        private readonly IDbSet<T> set;

        public Repository(DbContext context)
        {
            this.dbContext = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return this.set;
        }

        public T GetById(object id)
        {
            return this.set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Delete(object id)
        {
            var entity = this.GetById(id);
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
