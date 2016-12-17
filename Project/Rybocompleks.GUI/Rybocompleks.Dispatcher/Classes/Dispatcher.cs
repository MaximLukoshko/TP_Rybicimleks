using Rybocompleks.Controllers;
using Rybocompleks.Data;
using Rybocompleks.DecisionMakerModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rybocompleks.Dispatcher
{
    public class Dispatcher : IDispatcher, IActiveSensorsControllerListener
    {
        private Thread RunThread;
        Thread ClockThread;
        private Mutex mutex;

        private IDevicesController devicesController;
        private ISensorsController sensorsController;
        private IActiveSensorsController activeSensorsController;
        private IStateFormersController stateFormersController;
        private IGrowingPlanCommon growingPlan;
        private Int32 Hours;
        private Int32 Minutes;

        public Dispatcher(IGrowingPlanCommon gp)
        {
            mutex = new Mutex();
            RunThread = new Thread(Run);
            ClockThread = new Thread(Tic_Toc);

            Hours = 0;
            Minutes = 0;
            devicesController = new DevicesController();
            sensorsController = new SensorsController();
            activeSensorsController = new ActiveSensorsController(this);
            stateFormersController = new StateFormersController();
            growingPlan = gp;
        }

        public void RunFishGrowing()
        {
            activeSensorsController.RunMonitoring();
            RunThread.Start();
            ClockThread.Start();
        }

        public void StopFishGrowing()
        {
            RunThread.Abort();
            ClockThread.Abort();
            activeSensorsController.StopMonitoring();
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            ICollection<IShowInfo> ret;
            ICollection<IShowInfo> ret_devices;
            ICollection<IShowInfo> ret_sensors;
            ICollection<IShowInfo> ret_active_sensors;

            mutex.WaitOne();
            ret_devices = devicesController.GetShowInfo();
            ret_sensors = sensorsController.GetShowInfo();
            ret_active_sensors = activeSensorsController.GetShowInfo();
            mutex.ReleaseMutex();

            ret = ret_devices;
            foreach (IShowInfo sensor_shinf in ret_sensors)
                ret.Add(sensor_shinf);
            foreach (IShowInfo act_sensor_shinf in ret_active_sensors)
                ret.Add(act_sensor_shinf);

            return ret;
        }
        public IGPAllowedStates GetCurrentInstruction()
        {
            return growingPlan.GetAllowedStates(Hours, Minutes);
        }
        private Boolean AffectEnvironmentByStates(IList<IMeasurment> envStates)
        {
            IGPAllowedStates allowedStates = GetCurrentInstruction();
            if (null == allowedStates)
                return false;

            mutex.WaitOne();
            //Формируем инструкции для приборов
            IList<IMeasurment> reqStates = stateFormersController.FormDevicesInstructions(envStates, allowedStates);
            //Выставляем приборы в нужное состояние
            devicesController.AffectEnvironment(reqStates);
            mutex.ReleaseMutex();

            return true;
        }

        private Boolean MakeCycle()
        {
            Boolean ret = true;
            
            mutex.WaitOne();
            
            //Снимаем показания сенсоров и отправляем их для принятия решения и воздействия на окружающую среду
            IList<IMeasurment> sensStates = sensorsController.GetEnvironmentStates();
            if (false == AffectEnvironmentByStates(sensStates))
                ret = false;

            mutex.ReleaseMutex();

            return ret;
        }
        private void Tic_Toc()
        {
            while(true)
            {
                mutex.WaitOne();
                Minutes++;
                if (Minutes > 60)
                {
                    Hours++;
                    Minutes -= 60;
                }
                mutex.ReleaseMutex();
                Thread.Sleep(2000);//  1 минута в программе ~ 2 секунда в жизни
            }
        }
        private void Run()
        {
            while (true == MakeCycle())
                Thread.Sleep(4000);
        }
        public void Notify(IList<IMeasurment> dangerStates)
        {
            IList<IMeasurment> reqStates = new List<IMeasurment>();
            foreach (IMeasurment ds in dangerStates)
                reqStates.Add(ds);
            
            AffectEnvironmentByStates(reqStates);
        }

        public DateTime GetCurrentTime()
        {
            return (new DateTime()).AddHours(Hours).AddMinutes(Minutes);
        }
    }
}
