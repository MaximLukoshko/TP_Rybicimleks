using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers.Interfaces
{
    interface IDevicesController : IController
    {
        IDictionary<Int32,IMeasurment> GetDevicesStates();
        void AffectEnvironment(IDictionary<Int32, IMeasurment> reauiredStates);
    }
}
