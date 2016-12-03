using Perepherial.Classes;
using Rybocompleks.Data;
using Rybocompleks.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perepherial.Devices
{
    abstract class Device : IDevice
    {
        protected IMeasurment State = null;
        private Location location;

        public Device(Location loc)
        {
            location = loc;
            
            if (null == State)
                throw new NullReferenceException();
        }

        public abstract void SetState(Rybocompleks.Data.IMeasurment state);

        public Rybocompleks.Data.IMeasurment GetState()
        {
            return State;
        }

        public Rybocompleks.Data.Classes.Location GetLocation()
        {
            return location;
        }

        public void SetLocation(Rybocompleks.Data.Classes.Location loc)
        {
            location = loc;
        }

        public abstract int GetPropertyID();
        public abstract string GetName();
        public abstract int GetIcon();
     
    }
}
