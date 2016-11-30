using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rybocompleks.Data.Classes;

namespace Perepherial.Classes
{
    internal static class Environment
    {
        //Data
        private static TemperatureMeasurment Temperature = null;
        private static OxygenMeasurment Oxygen = null;
        private static PHMeasurment PH = null;
        private static LightMeasurment Light = null;
    }
}
