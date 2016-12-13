using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.GrowingPlan
{
    public interface IGrowingPlanCommon
    {
        IDictionary<MeasurmentTypes.Type, IInstruction> GetAllowedStates(Int32 hours, Int32 minutes);
    }
}
