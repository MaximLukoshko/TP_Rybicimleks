using Rybocompleks.Data;
using Rybocompleks.DecisionMakerModule;

namespace Rybocompleks.DecisionMakerModule
{
    internal class LightStateFormer : IStateFormer
    {



        public IMeasurment FormDevicesInstruction(IMeasurment currentState, IGPAllowedStates allowedStates)
        {
            // Добавить зависимость от прогресса
            //!!!!!
            //!!!!!
            //!!!!!
            //!!!!!
            //!!!!!
            //!!!!!
            return allowedStates.GetStateByPropertyID(GetPropertyID()).GetMaxAllowedState();
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.LightPerDay;
        }
    }
}
