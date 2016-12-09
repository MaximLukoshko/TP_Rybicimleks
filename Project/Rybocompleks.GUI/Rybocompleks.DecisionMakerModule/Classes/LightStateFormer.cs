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
