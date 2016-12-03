using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data.Classes
{
    public sealed class PHMeasurment : IPHMeasurment,IPhysicalObjectState
    {
        public PHMeasurment(Double ph)
        {
            PH = ph;
        }


        public Double GetPH()
        {
            return PH;
        }

        public Int32 GetPropertyID()
        {
            throw new NotImplementedException();
        }

        public int Compare(IMeasurment meas)
        {
            return PH.CompareTo(((PHMeasurment)meas).PH);
        }

        public String GetStringValue()
        {
            return PH.ToString() + "ph";
        }

        //Data
        private Double PH;
    }
}
