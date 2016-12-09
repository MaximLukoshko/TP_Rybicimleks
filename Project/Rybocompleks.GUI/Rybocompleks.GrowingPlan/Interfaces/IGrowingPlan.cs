using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rybocompleks.Data.Classes;
using Rybocompleks.Data;
using Rybocompleks.GrowingPlan.Classes;

namespace Rybocompleks.GrowingPlan.Interfaces
{
    public interface IGrowingPlan
    {
        List<GPInstruction> Instructions   {get;set;}
     //   Dictionary<MeasurmentTypes.Type, IMeasurment> getAllowedStates();          
    }
}
