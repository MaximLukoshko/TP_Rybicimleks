using Rybocompleks.Perepherial;
using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Perepherial
{
    abstract class Device : IDevice
    {
        protected IMeasurment State = null;
        protected Location location;

        public Device(Location loc)
        {
            location = loc;
            
            if (null == State)
                throw new NullReferenceException();
        }

        public abstract void SetState(IMeasurment state);

        public IMeasurment GetState()
        {
            return State;
        }

        public Rybocompleks.Data.Location GetLocation()
        {
            return location;
        }

        public void SetLocation(Rybocompleks.Data.Location loc)
        {
            location = loc;
        }

        public abstract MeasurmentTypes.Type GetPropertyID();
        public abstract string GetName();
        public abstract int GetIcon();
     
    }
}
