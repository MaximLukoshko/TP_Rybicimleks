using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rybocompleks.Data;

namespace Rybocompleks.Perepherial
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
                lock(temperature)
                {
                    temperature = new TemperatureMeasurment((temperature.GetTemperature() + value.GetTemperature() + +value.Compare(temperature)) / 2);
                }
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
                lock(oxygen)
                {
                    oxygen = new OxygenMeasurment((oxygen.GetOxygen() + value.GetOxygen() + value.Compare(oxygen)) / 2);
                }
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
                lock(ph)
                {
                    ph = new PHMeasurment((Double)((ph.GetPH() + value.GetPH()) / 2));
                }
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
                lock(light)
                {
                    light = new LightMeasurment(value.GetLightState());
                }
            }
        }
    }
}
