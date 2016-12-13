using Rybocompleks.Data;
using Rybocompleks.GrowingPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.GrowingPlan
{
    public class GrowingPlanCommon : IGrowingPlanCommon
    {
        protected IList<GPAllowedStates> AllowedStatesList;
        public GrowingPlanCommon(ICollection<IToGPAllowedStates> allowedStatesList)
        {
            AllowedStatesList = new List<GPAllowedStates>();
            foreach(IToGPAllowedStates state in allowedStatesList)
            {
                AllowedStatesList.Add(state.ToGPAllowedStates());
            }
        }
        public IDictionary<MeasurmentTypes.Type, IInstruction> GetAllowedStates(Int32 hours, Int32 minutes)
        {
            DateTime required = (new DateTime()).AddHours(hours).AddMinutes(minutes);
            for (Int32 i = 0; i < AllowedStatesList.Count - 1; i++)
            {
                DateTime currentInstructionTime = (new DateTime()).AddHours(AllowedStatesList[i].Hours).AddMinutes(AllowedStatesList[i].Minutes);
                DateTime nextInstructionTime = (new DateTime()).AddHours(AllowedStatesList[i + 1].Hours).AddMinutes(AllowedStatesList[i + 1].Minutes);

                if (currentInstructionTime <= required && nextInstructionTime > required)
                    return AllowedStatesList[i].AllowedStates;
            }
            return null;
        }
    }
}
