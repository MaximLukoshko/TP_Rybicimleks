﻿using Rybocompleks.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data.Classes
{
    public sealed class ShowInfo : IShowInfo
    {
        public IPhysicalObjectState State = null;

        //public IPhysicalObject Item = null;
    }
}
