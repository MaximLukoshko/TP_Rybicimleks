using Rybocompleks.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data.Interfaces
{
    public interface IPhysicalObject
    {
        Location GetLocation();
        void SetLocation(Location location);
        Int32 GetPropertyID();
        String GetName();
        Int32 GetIcon();
    }
}
