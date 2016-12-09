using Rybocompleks.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data.Classes
{
    public class Instruction : IInstruction
    {
        private IMeasurment MaxAllowedState;
        private IMeasurment MinAllowedState;

        public Instruction(IMeasurment maxAllowedState, IMeasurment minAllowedState)
        {
            if (null == maxAllowedState || null == minAllowedState)
                throw new NullReferenceException();
            
            MaxAllowedState = maxAllowedState;
            MinAllowedState = minAllowedState;
        }

        public IMeasurment GetMaxAllowedState()
        {
            return MaxAllowedState;
        }

        public IMeasurment GetMinAllowedState()
        {
            return MinAllowedState;
        }

        public MeasurmentTypes.Type GetPropertyID()
        {
            return MeasurmentTypes.Type.DefaultType;
        }
    }
}
