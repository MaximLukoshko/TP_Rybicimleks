using Rybocompleks.Data;
using System.Collections.Generic;

namespace Rybocompleks.DecisionMakerModule
{
     public interface IStateFormersController
    {
         IList<IMeasurment> FormDevicesInstructions(IList<IMeasurment> currentStates,
            IGPAllowedStates allowedStates);
    }
}
