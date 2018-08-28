namespace Inprout.Data.UnitOfWork.Contracts
{
    using Entities;
    using Repository.Contracts;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        IDeletableRepository<User> Users { get; }

        void Save();

        Task SaveAsync();
    }
}
