using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data.Classes
{
    public sealed class OxygenMeasurment : IOxygenMeasurrment, IPhysicalObjectState
    {
        public OxygenMeasurment(Int16 oxygen)
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
            return Oxygen.CompareTo(((OxygenMeasurment)meas).Oxygen);
        }

        public String GetStringValue()
        {
            return Oxygen.ToString() + "ox";
        }
        
        // Data
        private Int16 Oxygen;
    }
}
