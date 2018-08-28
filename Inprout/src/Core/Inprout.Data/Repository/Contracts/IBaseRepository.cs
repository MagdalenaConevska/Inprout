namespace Inprout.Data.Repository.Contracts
{
    public interface IBaseRepository<in T> where T : class
    {
        void Insert(T entity);

        void Update(T entity);
    }
}
