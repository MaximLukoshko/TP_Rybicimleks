﻿using Rybocompleks.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data.Interfaces
{
    public interface IPhysicalObject : IPropertyID
    {
        Location GetLocation();
        void SetLocation(Location location);
        String GetName();
        Int32 GetIcon();
    }
}
