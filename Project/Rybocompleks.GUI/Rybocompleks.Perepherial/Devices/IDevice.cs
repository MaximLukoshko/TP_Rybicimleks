using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Perepherial
{
    public interface IDevice : IPhysicalObject
    {
        void SetState(IMeasurment meas);
        IMeasurment GetState();
    }
}
