using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data
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
        public Instruction(IMeasurment allowedState)
        {
            if (null == allowedState)
                throw new NullReferenceException();

            MaxAllowedState = allowedState;
            MinAllowedState = allowedState;
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
