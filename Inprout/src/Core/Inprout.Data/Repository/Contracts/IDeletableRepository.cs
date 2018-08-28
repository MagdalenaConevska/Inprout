namespace Inprout.Data.Repository.Contracts
{
    using System.Linq;

    public interface IDeletableRepository<T> : IBaseRepository<T> where T : class
    {
        IQueryable<T> All(bool includeDeleted = false);
    }
}
