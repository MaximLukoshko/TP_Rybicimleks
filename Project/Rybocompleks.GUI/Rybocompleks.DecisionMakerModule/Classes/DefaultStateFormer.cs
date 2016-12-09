using Rybocompleks.Data;
using Rybocompleks.Data.Classes;
using Rybocompleks.Data.Interfaces;
using Rybocompleks.DecisionMakerModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.DecisionMakerModule.Classes
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
