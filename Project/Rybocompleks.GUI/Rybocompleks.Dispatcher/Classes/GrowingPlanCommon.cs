﻿using Rybocompleks.Data;
using Rybocompleks.Dispatcher;
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
                    //Заполнить прогресс
//                             !!!
//                             !!!
//                             !!!
//                             !!!
                    //

                    return AllowedStatesList[i];
                }
            }
            return null;
        }
    }
}