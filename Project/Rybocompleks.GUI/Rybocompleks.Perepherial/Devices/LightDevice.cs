using Rybocompleks.Perepherial;
using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Perepherial
{
    class LightDevice : Device
    {
        public LightDevice(Location loc) : base(loc)
        {
            SetState(new LightMeasurment(false));
        }
        public override void SetState(IMeasurment state)
        {
            State = null != (LightMeasurment)state ? state : new LightMeasurment(false);
            Nature.Light = (LightMeasurment)State;
        }

        public override MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.LightPerDay;
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
