using Rybocompleks.Data;

namespace Rybocompleks.DecisionMakerModule
{
    internal interface IStateFormer : IPropertyID
    {
        IMeasurment FormDevicesInstruction(IMeasurment currentState, IInstruction allowedStates);
    }
}
