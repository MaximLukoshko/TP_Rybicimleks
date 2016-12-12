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
        public int HoursPerDay { get; set; }
        public int CurrentInstruction_Hours { get; set; }

        public LightInstruction(Int32 hours_per_day)
        {
            HoursPerDay = hours_per_day;
        }
        public IMeasurment GetMaxAllowedState()
        {
            if (CurrentInstruction_Hours > HoursPerDay)
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
