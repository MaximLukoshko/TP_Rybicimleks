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

        private IDevicesController devicesController;
        private ISensorsController sensorsController;
        private IStateFormersController stateFormersController;
        private IGrowingPlan growingPlan;
        private Int32 Hours;
        private Int32 Minutes;

        public Dispatcher(IGrowingPlan gp)
        {
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
            
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            ICollection<IShowInfo> ret;
            ICollection<IShowInfo> ret_devices = devicesController.GetShowInfo();
            ICollection<IShowInfo> ret_sensors = sensorsController.GetShowInfo();

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
            
            IDictionary<MeasurmentTypes.Type, IMeasurment> envStates = sensorsController.GetEnvironmentStates();
//            IDictionary<MeasurmentTypes.Type, IMeasurment> devStates = devicesController.GetDevicesStates();

            
            IDictionary<MeasurmentTypes.Type, IMeasurment> reqStates = stateFormersController.FormDevicesInstructions(envStates,allowedStates);

            devicesController.AffectEnvironment(reqStates);

            return true;
        }
        private void Tic_Toc()
        {
            Minutes++;
            if(Minutes>60)
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
                Thread.Sleep(1000);
            }
        }
    }
}
