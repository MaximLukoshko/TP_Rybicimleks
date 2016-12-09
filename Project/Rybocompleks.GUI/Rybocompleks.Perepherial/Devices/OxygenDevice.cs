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
    class OxygenDevice : Device
    {
        public OxygenDevice(Location loc) : base(loc)
        {
            SetState( new OxygenMeasurment(0) );
        }
        public override void SetState(Rybocompleks.Data.IMeasurment state)
        {
            State = null != (IOxygenMeasurrment)state ? state : new OxygenMeasurment(0);
            Nature.Oxygen = (IOxygenMeasurrment)State;
        }

        public override MeasurmentTypes.Type GetPropertyID()
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            return "Регулятор кислорода";
        }

        public override int GetIcon()
        {
            throw new NotImplementedException();
        }
    }
}
