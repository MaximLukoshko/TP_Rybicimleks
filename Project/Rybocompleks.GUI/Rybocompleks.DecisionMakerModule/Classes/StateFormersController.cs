using Rybocompleks.Data;
using Rybocompleks.DecisionMakerModule;
using System.Collections.Generic;

namespace Rybocompleks.DecisionMakerModule
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
