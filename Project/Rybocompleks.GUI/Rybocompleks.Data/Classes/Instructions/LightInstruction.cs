using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data
{
    public class LightInstruction : IInstruction
    {
        public int TimeToSwitchOFF_Hours { get; set; }
        public int TimeToSwitchOFF_Minutes { get; set; }
        public int CurrentInstruction_Hours { get; set; }
        public int CurrentInstruction_Minutes { get; set; }

        public IMeasurment GetMaxAllowedState()
        {
            if (CurrentInstruction_Hours > TimeToSwitchOFF_Hours)
                return new LightMeasurment(false);

            if (CurrentInstruction_Hours < TimeToSwitchOFF_Hours)
                return new LightMeasurment(true);

            if (CurrentInstruction_Minutes > TimeToSwitchOFF_Minutes)
                return new LightMeasurment(false);

            return new LightMeasurment(true);
        }

        public IMeasurment GetMinAllowedState()
        {
            return GetMaxAllowedState();
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.LightPerDay;
        }
    }


}
