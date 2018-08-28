namespace Inprout.Data.Repository.Implementation
{
    using Entities.Contracts;
    using Contracts;
    using Context;
    using System.Data.Entity;

    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        protected IInproutDbContext InproutDbContext { get; }

        protected IDbSet<T> InproutDbSet { get; set; }

        public BaseRepository(IInproutDbContext inproutDbContext)
        {
            InproutDbContext = inproutDbContext;

            InproutDbSet = InproutDbContext.Set<T>();
        }

        public void Insert(T entity)
        {
            InproutDbSet.Add(entity);
        }

        public void Update(T entity)
        {
            InproutDbSet.Attach(entity);

            InproutDbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
