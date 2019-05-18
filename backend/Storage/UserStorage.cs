using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GT.Interfaces.Storage;
using GT.Models;
using Microsoft.EntityFrameworkCore;

namespace GT.Storage
{
    public class UserStorage : IUserStorage
    {
        public async Task<User> CreateAsync(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var entityEntry = await db.Users.AddAsync(user);
                await db.SaveChangesAsync();

                return entityEntry.Entity;
            }
        }

        public async Task<User> GetAsync(Guid? id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (id == null)
                    return await db.Users.FirstOrDefaultAsync();

                return await db.Users.FindAsync(id);
            }
        }
    }
}
