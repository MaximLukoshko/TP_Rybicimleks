using Rybocompleks.Data;
using Rybocompleks.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Rybocompleks.GrowingPlan
namespace Rybocompleks.Dispatcher
{
    public class GPAllowedStates : IGPAllowedStates
    { 
        public Double Progress{ get; set; }
        public String Name { get; private set; }
        public Int32 Hours { get; private set; }
        public Int32 Minutes { get; private set; }

        public IList<IInstruction> AllowedStates;
        public GPAllowedStates(String name, Int32 hours, Int32 minutes, IList<IInstruction> allowedStates)
        {
            Name = name;
            Hours = hours;
            Minutes = minutes;
            AllowedStates = allowedStates;
        }

        public IInstruction GetStateByPropertyID(MeasurmentTypes.Type id)
        {
            foreach (IInstruction state in AllowedStates)
                if (state.GetPropertyID() == id)
                    return state;

            return null;
        }
        
    }
}
