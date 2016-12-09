using Rybocompleks.Data;
using System.Collections.Generic;

namespace Rybocompleks.Controllers
{
    interface ISensorsController : IController
    {
        IDictionary<MeasurmentTypes.Type, IMeasurment> GetEnvironmentStates();
    }
}
