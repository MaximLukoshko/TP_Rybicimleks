using Rybocompleks.Data.Classes;
using Rybocompleks.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data
{
    public interface IMeasurment : IPhysicalObjectState, IPropertyID
    {
        int Compare(IMeasurment meas);
    }
}
