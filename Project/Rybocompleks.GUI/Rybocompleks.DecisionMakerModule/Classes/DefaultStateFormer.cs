using Rybocompleks.Data;
using Rybocompleks.DecisionMakerModule;

namespace Rybocompleks.DecisionMakerModule
{
    internal class DefaultStateFormer : IStateFormer
    {



        public IMeasurment FormDevicesInstruction(IMeasurment currentState, IInstruction allowedStates)
        {
            if (currentState.Compare(allowedStates.GetMinAllowedState()) == -1)
                return allowedStates.GetMaxAllowedState();
            
            if (currentState.Compare(allowedStates.GetMaxAllowedState()) == 11)
                return allowedStates.GetMinAllowedState();

            return currentState;
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.DefaultType;
        }
    }
}
