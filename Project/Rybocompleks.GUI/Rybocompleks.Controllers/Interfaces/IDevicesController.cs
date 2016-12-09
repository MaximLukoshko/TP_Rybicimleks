using Rybocompleks.Data;
using System.Collections.Generic;

namespace Rybocompleks.Controllers
{
    interface IDevicesController : IController
    {
        IDictionary<MeasurmentTypes.Type,IMeasurment> GetDevicesStates();
        void AffectEnvironment(IDictionary<MeasurmentTypes.Type, IMeasurment> reauiredStates);
    }
}
