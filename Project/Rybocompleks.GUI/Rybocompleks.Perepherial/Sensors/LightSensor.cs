using Rybocompleks.Perepherial;
using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Perepherial
{
    public class LightSensor : Sensor
    {
        public LightSensor(Location loc, String name = "Датчик освещённости")
            : base(loc, name)
        {
            Measure();

            // Присваиваем пустую строку, чтобы датчик не отображался, 
            // так как физически он не существует
            Name = ""; 
        }

        public override IMeasurment Measure()
        {
            lastMeasurment = Nature.Light;
            return lastMeasurment;
        }

        public override MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.LightPerDay;
        }
    }
}
