using Perepherial.Classes;
using Rybocompleks.Data;
using Rybocompleks.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perepherial.Sensors
{
    class PhSensor : Sensor
    {
        public PhSensor(Location loc) : base(loc)
        {
            Measure();
        }

        public override String GetName()
        {
            return "Датчик кислотности";
        }

        public override Int32 GetIcon()
        {
            throw new NotImplementedException();
        }

        public override IMeasurment Measure()
        {
            lastMeasurment = Nature.PH;
            return lastMeasurment;
        }
    }
}
