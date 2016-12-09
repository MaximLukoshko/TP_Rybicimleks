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
    class TemperatureDevice : Device
    {
        public TemperatureDevice(Location loc) : base(loc)
        {
            SetState( new TemperatureMeasurment(0) );
        }
        public override void SetState(Rybocompleks.Data.IMeasurment state)
        {
            State = null != (ITemperatureMeasurment)state ? state : new TemperatureMeasurment(0);
            Nature.Temperature = (ITemperatureMeasurment)State;
        }

        public override MeasurmentTypes.Type GetPropertyID()
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            return "Нагреватель";
        }

        public override int GetIcon()
        {
            throw new NotImplementedException();
        }
    }
}
