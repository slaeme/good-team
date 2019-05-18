using GT.Models;
using System;
using System.Threading.Tasks;

namespace GT.Interfaces
{
    public interface IDeedStorage
    {
        Task<Deed> GetAsync(Guid id);
        Task<Deed[]> GetAllAsync();
        Task<Deed> CreateAsync(Deed deed);
        Task<Deed> UpdateAsync(Deed deed);
        Task<bool> DeleteAsync(Guid id);
    }
}
