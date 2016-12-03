using Perepherial.Classes;
using Rybocompleks.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perepherial.Devices
{
    class LightDevice : Device
    {
        public LightDevice(Location loc) : base(loc)
        {
            SetState(new LightMeasurment(false));
        }
        public override void SetState(Rybocompleks.Data.IMeasurment state)
        {
            State = null != (LightMeasurment)state ? state : new LightMeasurment(false);
            Nature.Light = (LightMeasurment)State;
        }

        public override int GetPropertyID()
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            return "Лампа";
        }

        public override int GetIcon()
        {
            throw new NotImplementedException();
        }
    }
}
