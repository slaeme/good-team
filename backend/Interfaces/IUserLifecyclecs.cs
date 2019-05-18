using GT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Interfaces
{
    public interface IUserLifecycle
    {
        User Create(User deed);
        User Get(Guid id);
        User Get(string name);
    }
}
