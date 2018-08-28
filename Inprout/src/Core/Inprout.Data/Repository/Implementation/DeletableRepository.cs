namespace Inprout.Data.Repository.Implementation
{
    using Entities.Contracts;
    using Contracts;
    using System.Linq;
    using Context;

    public class DeletableRepository<T> : BaseRepository<T>, IDeletableRepository<T> where T : class, IDeletableEntity
    {
        public DeletableRepository(IInproutDbContext inproutDbContext) : base(inproutDbContext)
        {
        }

        public IQueryable<T> All(bool includeDeleted = false)
        {
            return includeDeleted ? InproutDbSet
                                  : InproutDbSet.Where(f => f.DeletedOn == null);
        }
    }
}
