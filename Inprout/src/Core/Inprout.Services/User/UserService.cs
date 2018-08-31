namespace Inprout.Services.User
{
    using System;
    using System.Threading.Tasks;
    using Contracts.User.Interfaces;
    using Contracts.User.Models;

    public class UserService : IUserService
    {
        public Task CreateUserAsync(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
