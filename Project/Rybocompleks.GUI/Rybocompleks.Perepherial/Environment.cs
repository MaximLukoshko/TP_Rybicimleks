using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rybocompleks.Data.Classes;
using Rybocompleks.Data;

namespace Perepherial.Classes
{
    internal static class Nature
    {
        //Data
        private static TemperatureMeasurment temperature = null;
        private static OxygenMeasurment oxygen = null;
        private static PHMeasurment ph = null;
        private static LightMeasurment light = null;

        static Nature()
        {
            temperature = new TemperatureMeasurment((new Random()).Next(0, 100));
            ph = new PHMeasurment(((new Random()).NextDouble()*10));
            oxygen = new OxygenMeasurment((new Random()).Next(0, 1000));
            light = new LightMeasurment(false);
        }

        public static ITemperatureMeasurment Temperature 
        { 
            get
            {                
                return temperature;
            } 

            set
            {
                temperature = new TemperatureMeasurment((temperature.GetTemperature() + value.GetTemperature()) / 2);
            } 
        }

        public static IOxygenMeasurrment Oxygen
        {
            get
            {
                return oxygen;
            }

            set
            {
                oxygen = new OxygenMeasurment((oxygen.GetOxygen() + value.GetOxygen()) / 2);
            }
        }

        public static IPHMeasurment PH
        {
            get
            {
                return ph;
            }

            set
            {
                ph = new PHMeasurment((Double)((ph.GetPH() + value.GetPH()) / 2));
            }
        }
        public static ILightMeasurment Light
        {
            get
            {
                return light;
            }

            set
            {
                light = new LightMeasurment(value.GetLightState());
            }
        }
    }
}
