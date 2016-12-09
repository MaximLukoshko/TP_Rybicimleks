using Rybocompleks.Data;
using Rybocompleks.DecisionMakerModule;

namespace Rybocompleks.DecisionMakerModule
{
    internal class LightStateFormer : IStateFormer
    {



        public IMeasurment FormDevicesInstruction(IMeasurment currentState, IInstruction allowedStates)
        {
            return allowedStates.GetMaxAllowedState();
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.LightPerDay;
        }
    }
}
