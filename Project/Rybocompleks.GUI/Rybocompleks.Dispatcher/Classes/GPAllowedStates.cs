using Rybocompleks.Data;
using Rybocompleks.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.GrowingPlan
{
    public class GPAllowedStates : IGPAllowedStates
    {
        public Double Progress{ get; set; }
        public String Name { get; private set; }
        public Int32 Hours { get; private set; }
        public Int32 Minutes { get; private set; }

        public IDictionary<MeasurmentTypes.Type, IInstruction> AllowedStates;
        public GPAllowedStates(String name, Int32 hours, Int32 minutes, IDictionary<MeasurmentTypes.Type, IInstruction> allowedStates)
        {
            Name = name;
            Hours = hours;
            Minutes = minutes;
            AllowedStates = allowedStates;
        }

        public IInstruction GetStateByPropertyID(MeasurmentTypes.Type id)
        {
            return AllowedStates[id];
        }
        
    }
}
