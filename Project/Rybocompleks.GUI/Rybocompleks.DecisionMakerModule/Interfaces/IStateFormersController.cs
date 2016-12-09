using Rybocompleks.Data;
using System.Collections.Generic;

namespace Rybocompleks.DecisionMakerModule
{
     public interface IStateFormersController
    {
         IDictionary<MeasurmentTypes.Type, IMeasurment> FormDevicesInstructions(IDictionary<MeasurmentTypes.Type, IMeasurment> currentStates, 
            IDictionary<MeasurmentTypes.Type, IInstruction> allowedStates);
    }
}
