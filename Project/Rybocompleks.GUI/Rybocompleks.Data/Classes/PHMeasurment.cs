using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data.Classes
{
    sealed class PHMeasurment : IPHMeasurment,IPhysicalObjectState
    {
        PHMeasurment(Double ph)
        {
            PH = ph;
        }


        public Double GetPH()
        {
            return PH;
        }

        public Int16 GetPropertyID()
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
