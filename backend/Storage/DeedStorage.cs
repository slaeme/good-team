using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GT.Interfaces;
using GT.Models;

namespace GT.Storage
{
    public class DeedStorage : IDeedStorage
    {
        public async Task<Deed> GetAsync(Guid id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return await db.Deeds.FindAsync(id);
            }
        }

        public async Task<Deed[]> GetAllAsync()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Deeds.ToArray();
            }
        }

        public async Task<Deed> CreateAsync(Deed deed)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var entityEntry = await db.Deeds.AddAsync(deed);
                await db.SaveChangesAsync();

                return entityEntry.Entity;
            }
        }

        public async Task<Deed> UpdateAsync(Deed deed)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Update(deed);
                await db.SaveChangesAsync();

                return deed;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var deed = await GetAsync(id);
                if (deed == null)
                    return true;

                db.Remove(deed);
                return await db.SaveChangesAsync() != 0;
            }
        }
    }


}
