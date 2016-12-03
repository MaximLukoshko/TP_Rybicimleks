using Rybocompleks.Data;
using Rybocompleks.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perepherial.Devices
{
    public interface IDevice : IPhysicalObject
    {
        void SetState(IMeasurment meas);
        IMeasurment GetState();
    }
}
