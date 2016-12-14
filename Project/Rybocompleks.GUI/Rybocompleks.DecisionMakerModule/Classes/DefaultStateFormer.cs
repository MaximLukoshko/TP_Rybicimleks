using Rybocompleks.Data;
using Rybocompleks.DecisionMakerModule;

namespace Rybocompleks.DecisionMakerModule
{
    internal class DefaultStateFormer : IStateFormer
    {



        public IMeasurment FormDevicesInstruction(IMeasurment currentState, IGPAllowedStates allowedStates)
        {
            IInstruction stateByProp = allowedStates.GetStateByPropertyID(GetPropertyID());
            if (currentState.Compare(stateByProp.GetMinAllowedState()) == -1)
                return stateByProp.GetMaxAllowedState();

            if (currentState.Compare(stateByProp.GetMaxAllowedState()) == 1)
                return stateByProp.GetMinAllowedState();

            return currentState;
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.DefaultType;
        }
    }
}
