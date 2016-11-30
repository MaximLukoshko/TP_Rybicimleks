using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data
{
    public interface IMeasurment
    {
        Int16 GetPropertyID();
        int Compare(IMeasurment meas);
    }
}
