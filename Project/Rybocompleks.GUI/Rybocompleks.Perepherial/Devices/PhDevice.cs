using Perepherial.Classes;
using Rybocompleks.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perepherial.Devices
{
    class PhDevice : Device
    {
        public PhDevice (Location loc) : base(loc)
        {
            SetState( new PHMeasurment(0) );
        }
        public override void SetState(Rybocompleks.Data.IMeasurment state)
        {
            State = null != (PHMeasurment)state ? state : new PHMeasurment(0);
            Nature.PH = (PHMeasurment)State;
        }

        public override int GetPropertyID()
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            return "Регулятор кислотности";
        }

        public override int GetIcon()
        {
            throw new NotImplementedException();
        }
    }
}
