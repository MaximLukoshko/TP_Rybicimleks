using Rybocompleks.Perepherial;
using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Perepherial
{
    public class OxygenSensor : Sensor
    {
        public OxygenSensor(Location loc, String name="Датчик кислорода") : base(loc,name)
        {
            Measure();
        }

        public override IMeasurment Measure()
        {
            lastMeasurment = Nature.Oxygen;
            return lastMeasurment;
        }

        public override MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.Oxygen;
        }
    }
}
