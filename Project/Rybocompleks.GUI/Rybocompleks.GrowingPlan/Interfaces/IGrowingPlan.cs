using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rybocompleks.Data;
using Rybocompleks.GrowingPlan;

namespace Rybocompleks.GrowingPlan
{
    public interface IGrowingPlan
    {
        List<GPInstruction> Instructions   {get;set;}
     //   Dictionary<MeasurmentTypes.Type, IMeasurment> getAllowedStates();          
    }
}
