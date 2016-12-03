using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data.Classes
{
    public sealed class TemperatureMeasurment : ITemperatureMeasurment, IPhysicalObjectState
    {
        public TemperatureMeasurment(Int32 temperature)
        {
            Temperature = temperature;
        }


        public Int32 GetTemperature()
        {
            return Temperature;
        }

        public Int32 GetPropertyID()
        {
            throw new NotImplementedException();
        }

        public int Compare(IMeasurment meas)
        {
            return Temperature.CompareTo(((TemperatureMeasurment)meas).Temperature);
        }

        public String GetStringValue()
        {
            return Temperature.ToString() + " grad";
        }

        //Data
        private Int32 Temperature;
    }
}
