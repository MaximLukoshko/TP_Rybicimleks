using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rybocompleks.Data;
using System.Threading;

namespace Rybocompleks.Perepherial
{
    // Данный класс моделирует поведение окружающей среды
    // public - для того, чтобы можно было остановить поток изменения состояния
    public static class Nature
    {
        //Data
        private static TemperatureMeasurment    temperatureMustBe     = null;
        private static OxygenMeasurment         oxygenMustBe          = null;
        private static PHMeasurment             phMustBe              = null;
        private static LightMeasurment          lightMustBe           = null;

        private static TemperatureMeasurment    temperatureReal     = null;
        private static OxygenMeasurment         oxygenReal          = null;
        private static PHMeasurment             phReal              = null;
        private static LightMeasurment          lightReal           = null;

        //поток изменения состояния
        public static Thread environmentThread { get; private set; }
        static Nature()
        {

            temperatureReal   = new TemperatureMeasurment((new Random()).Next(0, 100));
            phReal            = new PHMeasurment(((new Random()).NextDouble() * 7));
            oxygenReal        = new OxygenMeasurment((new Random()).Next(0, 1000));
            lightReal         = new LightMeasurment(false);

            temperatureMustBe   = temperatureReal;
            phMustBe            = phReal;
            oxygenMustBe        = oxygenReal;
            lightMustBe         = lightReal;

            environmentThread = new Thread(Change);
        }

        private static void Change()
        {
            while (true)
            {
                lock (temperatureMustBe)
                {
                    lock (temperatureReal)
                    {
                        temperatureReal = new TemperatureMeasurment(temperatureReal.GetTemperature() +
                            (temperatureMustBe.GetTemperature() - temperatureReal.GetTemperature()
                            + 4 * temperatureMustBe.Compare(temperatureReal)) / 5);
                    }
                }
                lock (phMustBe)
                {
                    lock (phReal)
                    {
                        phReal = new PHMeasurment(phReal.GetPH() +
                            (phMustBe.GetPH() - phReal.GetPH()) / 5);
                    }
                }
                lock (oxygenMustBe)
                {
                    lock (oxygenReal)
                    {
                        oxygenReal = new OxygenMeasurment(oxygenReal.GetOxygen() +
                            (oxygenMustBe.GetOxygen() - oxygenReal.GetOxygen()
                            + 4 * oxygenMustBe.Compare(oxygenReal)) / 5);
                    }
                }

                Thread.Sleep(400);
            }
        }

        public static ITemperatureMeasurment Temperature 
        { 
            get
            {
                return temperatureReal;
            } 

            set
            {
                lock(temperatureMustBe)
                {
                    temperatureMustBe = new TemperatureMeasurment(value.GetTemperature());
                }
            } 
        }

        public static IOxygenMeasurrment Oxygen
        {
            get
            {
                return oxygenReal;
            }

            set
            {
                lock(oxygenMustBe)
                {
                    oxygenMustBe = new OxygenMeasurment(value.GetOxygen());
                }
            }
        }

        public static IPHMeasurment PH
        {
            get
            {
                return phReal;
            }

            set
            {
                lock(phMustBe)
                {
                    phMustBe = new PHMeasurment(value.GetPH());
                }
            }
        }
        public static ILightMeasurment Light
        {
            get
            {
                return lightReal;
            }

            set
            {
                lock(lightMustBe)
                {
                    lightMustBe = new LightMeasurment(value.GetLightState());
                    lock(lightReal)
                    {
                        lightReal = lightMustBe;
                    }
                }
            }
        }
    }
}
