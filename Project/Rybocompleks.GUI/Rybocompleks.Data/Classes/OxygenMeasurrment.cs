using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data.Classes
{
    sealed class OxygenMeasurrment : IOxygenMeasurrment, IPhysicalObjectState
    {
        OxygenMeasurrment(Int16 oxygen)
        {
            Oxygen = oxygen;
        }

        public Int16 GetOxygen()
        {
            return Oxygen;
        }

        public Int16 GetPropertyID()
        {
            throw new NotImplementedException();
        }

        public int Compare(IMeasurment meas)
        {
            return Oxygen.CompareTo(((OxygenMeasurrment)meas).Oxygen);
        }

        public String GetStringValue()
        {
            return Oxygen.ToString() + "ox";
        }
        
        // Data
        private Int16 Oxygen;
    }
}
