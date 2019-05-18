using System;
using GT.Interfaces;
using GT.Models;

namespace GT.Domain
{
    public class UserLifecycle : IUserLifecycle
    {
        public User Create(User deed)
        {
            throw new NotImplementedException();
        }

        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public User Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
