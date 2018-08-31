namespace Inprout.Contracts.User.Interfaces
{
    using Models;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task CreateUserAsync(CreateUserRequest request);
    }
}
