using Rybocompleks.Controllers;
using Rybocompleks.Data;
using Rybocompleks.DecisionMakerModule;
using Rybocompleks.GrowingPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Dispatcher
{
    public class Dispatcher : IDispatcher
    {
        private IDevicesController devicesController;
        private ISensorsController sensorsController;
        private IStateFormersController stateFormersController;
        private IGrowingPlan growingPlan;
        private Int32 Hours;
        private Int32 Minutes;

        public Dispatcher(IGrowingPlan gp)
        {
            Hours = 0;
            Minutes = 0;
            devicesController = new DevicesController();
            sensorsController = new SensorsController();
            stateFormersController = new StateFormersController();
            growingPlan = new GrowingPlanList();
        }

        public void RunFishGrowing()
        {
            throw new NotImplementedException();
        }

        public void StopFishGrowing()
        {
            throw new NotImplementedException();
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

        private void MakeCycle()
        {
            IDictionary<MeasurmentTypes.Type, IMeasurment> envStates = sensorsController.GetEnvironmentStates();
//            IDictionary<MeasurmentTypes.Type, IMeasurment> devStates = devicesController.GetDevicesStates();

            IDictionary<MeasurmentTypes.Type, IInstruction> allowedStates = growingPlan.GetAllowedStates(Hours, Minutes);
            
            IDictionary<MeasurmentTypes.Type, IMeasurment> reqStates = stateFormersController.FormDevicesInstructions(envStates,allowedStates);

            devicesController.AffectEnvironment(reqStates);
        }
    }
}
