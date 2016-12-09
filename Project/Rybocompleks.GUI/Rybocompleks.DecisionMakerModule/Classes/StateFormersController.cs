using Rybocompleks.Data;
using Rybocompleks.Data.Classes;
using Rybocompleks.Data.Interfaces;
using Rybocompleks.DecisionMakerModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.DecisionMakerModule.Classes
{
     public class StateFormersController : IStateFormersController
    {
         private IDictionary<MeasurmentTypes.Type, IStateFormer> StateFormers;
         public StateFormersController()
         {
             StateFormers = new Dictionary<MeasurmentTypes.Type, IStateFormer>();
         }

         public IDictionary<MeasurmentTypes.Type, IMeasurment> FormDevicesInstructions(IDictionary<MeasurmentTypes.Type, IMeasurment> currentStates, IDictionary<MeasurmentTypes.Type, IInstruction> allowedStates)
         {
             IDictionary<MeasurmentTypes.Type, IMeasurment> ret = new Dictionary<MeasurmentTypes.Type, IMeasurment>();
             
             foreach(IMeasurment curState in currentStates.Values)
             {
                 IStateFormer former = StateFormers[curState.GetPropertyID()];
                 if (null == former)
                     former = StateFormers[MeasurmentTypes.Type.DefaultType];

                 ret.Add(curState.GetPropertyID(),
                     former.FormDevicesInstruction(curState, allowedStates[curState.GetPropertyID()]));
             }

             return ret;
         }
    }
}
