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

        public LightInstruction(Int32 hours_per_day)
        {
            HoursPerDay = hours_per_day;
        }
        public IMeasurment GetMaxAllowedState()
        {
            return new LightMeasurment(true);
        }

        public IMeasurment GetMinAllowedState()
        {
            return new LightMeasurment(false);
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.LightPerDay;
        }
    }


}
