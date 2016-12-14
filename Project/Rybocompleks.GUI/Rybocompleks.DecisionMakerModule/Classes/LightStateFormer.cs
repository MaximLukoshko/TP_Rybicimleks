using Rybocompleks.Data;
using Rybocompleks.DecisionMakerModule;

namespace Rybocompleks.DecisionMakerModule
{
    internal class LightStateFormer : IStateFormer
    {



        public IMeasurment FormDevicesInstruction(IMeasurment currentState, IGPAllowedStates allowedStates)
        {
            return allowedStates.GetStateByPropertyID(GetPropertyID()).GetMaxAllowedState();
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.LightPerDay;
        }
    }
}
