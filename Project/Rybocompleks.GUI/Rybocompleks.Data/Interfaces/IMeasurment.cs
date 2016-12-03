using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data
{
    public interface IMeasurment : IPhysicalObjectState
    {
        Int32 GetPropertyID();
        int Compare(IMeasurment meas);
    }
}
