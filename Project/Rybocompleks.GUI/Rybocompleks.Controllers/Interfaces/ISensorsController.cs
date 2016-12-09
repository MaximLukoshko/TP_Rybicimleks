using Rybocompleks.Data;
using Rybocompleks.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers.Interfaces
{
    interface ISensorsController : IController
    {
        IDictionary<MeasurmentTypes.Type, IMeasurment> GetEnvironmentStates();
    }
}
