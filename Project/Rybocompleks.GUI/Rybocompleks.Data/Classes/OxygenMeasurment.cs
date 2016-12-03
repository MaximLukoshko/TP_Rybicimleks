using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data.Classes
{
    public sealed class OxygenMeasurment : IOxygenMeasurrment, IPhysicalObjectState
    {
        public OxygenMeasurment(Int32 oxygen)
        {
            Oxygen = oxygen;
        }

        public Int32 GetOxygen()
        {
            return Oxygen;
        }

        public Int32 GetPropertyID()
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
        private Int32 Oxygen;
    }
}
