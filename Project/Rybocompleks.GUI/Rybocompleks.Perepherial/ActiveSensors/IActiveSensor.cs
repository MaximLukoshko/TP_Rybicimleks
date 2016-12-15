using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perepherial.ActiveSensors
{
    public interface IActiveSensor : IPhysicalObject
    {
        IMeasurment GetState();
        Boolean IsEnvironmentOK(IInstruction allowedStates);
    }
}
