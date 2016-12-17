using Rybocompleks.Data;
using System.Collections.Generic;

namespace Rybocompleks.Controllers
{
    public interface ISensorsController : IController
    {
        IList<IMeasurment> GetEnvironmentStates();
    }
}
