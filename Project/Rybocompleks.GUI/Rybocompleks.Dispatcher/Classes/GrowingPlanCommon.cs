using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Rybocompleks.GrowingPlan
namespace Rybocompleks.Dispatcher
{
    public class GrowingPlanCommon : IGrowingPlanCommon
    {
        protected IList<IGPAllowedStates> AllowedStatesList;
        public GrowingPlanCommon(ICollection<IToIGPAllowedStates> allowedStatesList)
        {
            AllowedStatesList = new List<IGPAllowedStates>();
            foreach(IToIGPAllowedStates state in allowedStatesList)
            {
                AllowedStatesList.Add(state.ToIGPAllowedStates());
            }
        }
        public IGPAllowedStates GetAllowedStates(Int32 hours, Int32 minutes)
        {
            DateTime required = (new DateTime()).AddHours(hours).AddMinutes(minutes);
            for (Int32 i = 0; i < AllowedStatesList.Count - 1; i++)
            {
                DateTime currentInstructionTime = (new DateTime()).AddHours(AllowedStatesList[i].Hours).AddMinutes(AllowedStatesList[i].Minutes);
                DateTime nextInstructionTime = (new DateTime()).AddHours(AllowedStatesList[i + 1].Hours).AddMinutes(AllowedStatesList[i + 1].Minutes);

                if (currentInstructionTime <= required && nextInstructionTime > required)
                {
                    AllowedStatesList[i].Progress =
                        (Double)((required.Hour - currentInstructionTime.Hour) * 60 +
                        (required.Minute - currentInstructionTime.Minute)) /
                        (Double)((nextInstructionTime.Hour - currentInstructionTime.Hour) * 60 +
                        (nextInstructionTime.Minute - currentInstructionTime.Minute));

                    return AllowedStatesList[i];
                }
            }
            return null;
        }
    }
}
