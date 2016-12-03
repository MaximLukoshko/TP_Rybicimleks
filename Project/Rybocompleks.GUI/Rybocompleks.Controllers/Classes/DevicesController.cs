using Rybocompleks.Controllers.Interfaces;
using Rybocompleks.Data;
using Rybocompleks.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers.Classes
{
    class DevicesController : IDevicesController
    {
        public DevicesController()
        {
            throw new NotImplementedException();
        }

        public IDictionary<Int32, IMeasurment> GetDevicesStates()
        {
            throw new NotImplementedException();
        }

        public void AffectEnvironment(IDictionary<Int32, IMeasurment> reauiredStates)
        {
            throw new NotImplementedException();
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            throw new NotImplementedException();
        }
    }
}
