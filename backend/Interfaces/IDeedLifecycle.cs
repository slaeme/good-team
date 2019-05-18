using GT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Interfaces
{
    public interface IDeedLifecycle
    {
        Deed Create(Deed deed);
        Deed Update(Deed deed);
        bool Delete(Guid id);
    }
}
