using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers
{
    public interface IActiveSensorsController : IController
    {
        void RunMonitoring();
        void StopMonitoring();
    }
}

