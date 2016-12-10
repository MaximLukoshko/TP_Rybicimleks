using Rybocompleks.Controllers;
using Rybocompleks.Data;
using Rybocompleks.DecisionMakerModule;
using Rybocompleks.GrowingPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rybocompleks.Dispatcher
{
    public class Dispatcher : IDispatcher
    {
        private Thread RunThread;
        private Mutex mutex;

        private IDevicesController devicesController;
        private ISensorsController sensorsController;
        private IStateFormersController stateFormersController;
        private IGrowingPlan growingPlan;
        private Int32 Hours;
        private Int32 Minutes;

        public Dispatcher(IGrowingPlan gp)
        {
            mutex = new Mutex();
            RunThread = new Thread(Run);
            
            Hours = 0;
            Minutes = 0;
            devicesController = new DevicesController();
            sensorsController = new SensorsController();
            stateFormersController = new StateFormersController();
            growingPlan = new GrowingPlanList();
        }

        public void RunFishGrowing()
        {
            RunThread.Start();
        }

        public void StopFishGrowing()
        {
            RunThread.Abort();
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            ICollection<IShowInfo> ret;
            ICollection<IShowInfo> ret_devices;
            ICollection<IShowInfo> ret_sensors;

            mutex.WaitOne();
            ret_devices = devicesController.GetShowInfo();
            ret_sensors = sensorsController.GetShowInfo();
            mutex.ReleaseMutex();

            ret = ret_devices;
            foreach (IShowInfo sensor_shinf in ret_sensors)
                ret.Add(sensor_shinf);

            return ret;
        }

        private Boolean MakeCycle()
        {
                IDictionary<MeasurmentTypes.Type, IInstruction> allowedStates = growingPlan.GetAllowedStates(Hours, Minutes);
                if (null == allowedStates)
                    return false;
            
            mutex.WaitOne();
            //Снимаем показания сенсоров
            IDictionary<MeasurmentTypes.Type, IMeasurment> envStates = sensorsController.GetEnvironmentStates();
            // Снимаем состояние приборов
            //IDictionary<MeasurmentTypes.Type, IMeasurment> devStates = devicesController.GetDevicesStates
            //Формируем инструкции для приборов
            IDictionary<MeasurmentTypes.Type, IMeasurment> reqStates = stateFormersController.FormDevicesInstructions(envStates,allowedStates);
            //Выставляем приборы в нужное состояние
            devicesController.AffectEnvironment(reqStates);
            mutex.ReleaseMutex();

            return true;
        }
        private void Tic_Toc()
        {
            Minutes++;
            if (Minutes > 60)
            {
                Hours++;
                Minutes -= 60;
            }
        }
        private void Run()
        {
            while (true == MakeCycle())
            {
                Tic_Toc();
                Thread.Sleep(1000); //  1 минута в программе ~ 1 секунда в жизни
            }
        }
    }
}
