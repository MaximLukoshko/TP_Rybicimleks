using Rybocompleks.Perepherial;
using Rybocompleks.Controllers;
using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers
{
    public class DevicesController : IDevicesController
    {
        protected Controller<IDevice> physicalObjectsController;
        public DevicesController()
        {
            physicalObjectsController = new Controller<IDevice>();
            physicalObjectsController.AddObject(new TemperatureDevice(new Location(10, 10)));
            physicalObjectsController.AddObject(new OxygenDevice(new Location(10, 30)));
            physicalObjectsController.AddObject(new PhDevice(new Location(10, 80)));
            physicalObjectsController.AddObject(new LightDevice(new Location(10, 50)));
        }

        public IDictionary<MeasurmentTypes.Type, IMeasurment> GetDevicesStates()
        {
            IDictionary<MeasurmentTypes.Type, IMeasurment> ret = new Dictionary<MeasurmentTypes.Type, IMeasurment>();
            IDictionary<MeasurmentTypes.Type, IDevice> devices = physicalObjectsController.GetPhysicalObjects();

            foreach(IDevice dev in devices.Values)
                ret.Add(dev.GetPropertyID(), dev.GetState());

            return ret;
        }

        public void AffectEnvironment(IDictionary<MeasurmentTypes.Type, IMeasurment> reauiredStates)
        {
            IDictionary<MeasurmentTypes.Type, IDevice> devices = physicalObjectsController.GetPhysicalObjects();

            foreach (IMeasurment meas in reauiredStates.Values)
            {
                IDevice dev = devices[meas.GetPropertyID()];
                dev.SetState(meas);
            }
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            List<IShowInfo> ret = new List<IShowInfo>();
            IDictionary<MeasurmentTypes.Type, IDevice> devices = physicalObjectsController.GetPhysicalObjects();

            foreach(IDevice it in devices.Values)
            {
                ShowInfo shInf = new ShowInfo();
                shInf.State=it.GetState();
                shInf.Item = it;
                ret.Add(shInf);
            }

            return ret;
        }
    }
}
