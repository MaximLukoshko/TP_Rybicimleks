using Rybocompleks.Data;
using Rybocompleks.Perepherial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perepherial.ActiveSensors
{
    public class ActiveTemperatureSensor : ActiveSensor
    {
        public ActiveTemperatureSensor(Location loc, String name = "Активный термометр")
            : base(loc, name)
        {
        }

        public override IMeasurment GetState()
        {
            return Nature.Temperature;
        }

        public override MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.Temperature;
        }
    }
}
