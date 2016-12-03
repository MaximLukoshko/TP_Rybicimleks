using Perepherial.Devices;
using Rybocompleks.Controllers.Interfaces;
using Rybocompleks.Data;
using Rybocompleks.Data.Classes;
using Rybocompleks.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers.Classes
{
    class DevicesController : IDevicesController
    {
        protected Controller<IDevice> physicalObjectsController;
        public DevicesController()
        {
            physicalObjectsController = new Controller<IDevice>();
        }

        public IDictionary<Int32, IMeasurment> GetDevicesStates()
        {
            IDictionary<Int32, IMeasurment> ret = new Dictionary<Int32, IMeasurment>();
            IDictionary<Int32, IDevice> devices = physicalObjectsController.GetPhysicalObjects();

            foreach(IDevice dev in devices.Values)
                ret.Add(dev.GetPropertyID(), dev.GetState());

            return ret;
        }

        public void AffectEnvironment(IDictionary<Int32, IMeasurment> reauiredStates)
        {
            IDictionary<Int32, IDevice> devices = physicalObjectsController.GetPhysicalObjects();

            foreach (IMeasurment meas in reauiredStates.Values)
            {
                IDevice dev = devices[meas.GetPropertyID()];
                dev.SetState(meas);
            }
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            List<IShowInfo> ret = new List<IShowInfo>();
            IDictionary<Int32, IDevice> devices = physicalObjectsController.GetPhysicalObjects();

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
