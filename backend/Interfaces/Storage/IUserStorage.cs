using GT.Models;
using System;
using System.Threading.Tasks;

namespace GT.Interfaces.Storage
{
    public interface IUserStorage
    {
        Task<User> CreateAsync(User user);
        Task<User> GetAsync(Guid? id);
    }
}
