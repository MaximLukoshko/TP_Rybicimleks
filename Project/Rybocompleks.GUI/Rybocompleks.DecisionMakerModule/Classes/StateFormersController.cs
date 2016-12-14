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
             StateFormers.Add(MeasurmentTypes.Type.DefaultType, new DefaultStateFormer());
             StateFormers.Add(MeasurmentTypes.Type.LightPerDay, new LightStateFormer());
         }

         public IDictionary<MeasurmentTypes.Type, IMeasurment> FormDevicesInstructions(IDictionary<MeasurmentTypes.Type, IMeasurment> currentStates, 
             IGPAllowedStates allowedStates)
         {
             IDictionary<MeasurmentTypes.Type, IMeasurment> ret = new Dictionary<MeasurmentTypes.Type, IMeasurment>();
             
             foreach(IMeasurment curState in currentStates.Values)
             {
                 IStateFormer former = null;
                 if(StateFormers.ContainsKey(curState.GetPropertyID()))    
                    former = StateFormers[curState.GetPropertyID()];
                 else
                     former = StateFormers[MeasurmentTypes.Type.DefaultType];

                 ret.Add(curState.GetPropertyID(),
                     former.FormDevicesInstruction(curState, allowedStates));
             }

             return ret;
         }
    }
}
