using Rybocompleks.Perepherial;
using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Perepherial
{
    public class OxygenDevice : Device
    {
        public OxygenDevice(Location loc, String name = "Регулятор кислорода")
            : base(loc,name)
        {
            SetState( new OxygenMeasurment(0) );
        }
        public override void SetState(IMeasurment state)
        {
            State = null != (IOxygenMeasurrment)state ? state : new OxygenMeasurment(0);
            Nature.Oxygen = (IOxygenMeasurrment)State;
        }

        public override MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.Oxygen;
        }
    }
}
