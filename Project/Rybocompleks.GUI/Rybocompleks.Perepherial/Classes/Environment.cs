using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rybocompleks.Data.Classes;
using Rybocompleks.Data;

namespace Perepherial.Classes
{
    internal static class Environment
    {
        //Data
        private static TemperatureMeasurment temperature = null;
        private static OxygenMeasurment oxygen = null;
        private static PHMeasurment ph = null;
        private static LightMeasurment light = null;

        static Environment()
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
                //Если температура не задана, присваиваем ей случайное значение от 0 до 100
//                 if (null == temperature)
//                     temperature = new TemperatureMeasurment((Int32)((new Random()).Next(0, 100)));
                
                return temperature;
            } 

            set
            {
                //Если температура не задана, присваиваем ей случайное значение от 0 до 100
//                 if (null == temperature)
//                     temperature = new TemperatureMeasurment((Int32)((new Random()).Next(0, 100)));
                
                temperature = new TemperatureMeasurment( (Int32)((temperature.GetTemperature() + ((ITemperatureMeasurment)value).GetTemperature())/2) );
            } 
        }

        public static IOxygenMeasurrment Oxygen
        {
            get
            {
                //Если кислород не задан, присваиваем ему случайное значение от 0 до 1000
//                 if (null == oxygen)
//                     oxygen = new OxygenMeasurment((Int32)((new Random()).Next(0, 1000)));

                return oxygen;
            }

            set
            {
                //Если кислород не задан, присваиваем ему случайное значение от 0 до 1000
//                 if (null == oxygen)
//                     oxygen = new OxygenMeasurment((Int32)((new Random()).Next(0, 1000)));

                oxygen = new OxygenMeasurment((Int32)((oxygen.GetOxygen() + ((IOxygenMeasurrment)value).GetOxygen()) / 2));
            }
        }

        public static IPHMeasurment PH
        {
            get
            {
                //Если кислотность не задана, присваиваем ей случайное значение от 0 до 7,5
//                 if (null == ph)
//                     ph = new PHMeasurment((Double)((new Random()).Next(0, 1000)/156));

                return ph;
            }

            set
            {
                //Если кислотность не задана, присваиваем ей случайное значение от 0 до 7,5
//                 if (null == ph)
//                     ph = new PHMeasurment((Double)((new Random()).Next(0, 1000) / 156));

                ph = new PHMeasurment((Double)((ph.GetPH() + ((IPHMeasurment)value).GetPH()) / 2));
            }
        }
    }
}
