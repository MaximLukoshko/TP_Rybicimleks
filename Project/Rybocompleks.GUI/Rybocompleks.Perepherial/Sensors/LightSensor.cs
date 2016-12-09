﻿using Perepherial.Classes;
using Rybocompleks.Data;
using Rybocompleks.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perepherial.Sensors
{
    class LightSensor : Sensor
    {
        public LightSensor(Location loc) : base(loc)
        {
            Measure();
        }

        public override String GetName()
        {
            return "Датчик освещённости";
        }

        public override Int32 GetIcon()
        {
            throw new NotImplementedException();
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
