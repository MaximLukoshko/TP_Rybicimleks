using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data.Classes 
{
    public sealed class LightMeasurment :ILightMeasurment,IPhysicalObjectState
    {
        public LightMeasurment( Boolean turnedOn)
        {
            TurnedOn = turnedOn;
        }


        public Boolean GetLightState()
        {
            return TurnedOn;
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.LightPerDay;
        }

        public int Compare(IMeasurment meas)
        {
            if (TurnedOn == ((LightMeasurment)meas).TurnedOn)
                return 0;
            else if (TurnedOn)
                return 1;
            else
                return -1;
        }

        public String GetStringValue()
        {
            return "Лампа " + (TurnedOn ? "включена" : "выключена");
        }

        //Data
        private Boolean TurnedOn;
    }
}
