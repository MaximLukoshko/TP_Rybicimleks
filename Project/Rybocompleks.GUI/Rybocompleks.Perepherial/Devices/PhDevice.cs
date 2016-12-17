using Rybocompleks.Perepherial;
using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Perepherial
{
    public class PhDevice : Device
    {
        public PhDevice(Location loc, String name = "Дозатор питательных веществ") : base(loc,name)
        {
            SetState( new PHMeasurment(0) );
        }
        public override void SetState(IMeasurment state)
        {
            State = null != (PHMeasurment)state ? state : new PHMeasurment(0);
            Nature.PH = (PHMeasurment)State;
        }

        public override MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.PH;
        }
    }
}
