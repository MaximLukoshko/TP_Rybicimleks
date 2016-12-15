using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perepherial.ActiveSensors
{
    public abstract class ActiveSensor : IActiveSensor
    {
        protected Location location;
        public String Name{ get; set; }


        public ActiveSensor(Location loc, String name)
        {
            location = loc;
            Name = name;
        }

        public abstract IMeasurment GetState();

        public Location GetLocation()
        {
            return location;
        }

        public void SetLocation(Location loc)
        {
           location = loc;
        }

        public abstract MeasurmentTypes.Type GetPropertyID();
    }
}
