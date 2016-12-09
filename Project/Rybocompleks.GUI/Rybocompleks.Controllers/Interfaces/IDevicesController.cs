using Rybocompleks.Data;
using Rybocompleks.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers.Interfaces
{
    interface IDevicesController : IController
    {
        IDictionary<MeasurmentTypes.Type,IMeasurment> GetDevicesStates();
        void AffectEnvironment(IDictionary<MeasurmentTypes.Type, IMeasurment> reauiredStates);
    }
}
