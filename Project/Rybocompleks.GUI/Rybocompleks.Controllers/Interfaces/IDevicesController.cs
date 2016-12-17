using Rybocompleks.Data;
using System.Collections.Generic;

namespace Rybocompleks.Controllers
{
    public interface IDevicesController : IController
    {
        IList<IMeasurment> GetDevicesStates();
        void AffectEnvironment(IList<IMeasurment> reauiredStates);
    }
}
