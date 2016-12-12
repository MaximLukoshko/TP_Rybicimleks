using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.GrowingPlan
{
    public class GPAllowedStates
    {
        public String Name { get; set; }
        public Int32 Hours { get; set; }
        public Int32 Minutes { get; set; }

        public IDictionary<MeasurmentTypes.Type, IInstruction> AllowedStates;
        public GPAllowedStates(String name, Int32 hours, Int32 minutes, IDictionary<MeasurmentTypes.Type, IInstruction> allowedStates)
        {
            Name = name;
            Hours = hours;
            Minutes = minutes;
            AllowedStates = allowedStates;
        }
        
    }
}
