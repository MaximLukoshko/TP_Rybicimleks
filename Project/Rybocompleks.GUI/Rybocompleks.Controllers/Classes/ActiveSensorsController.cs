using Perepherial.ActiveSensors;
using Rybocompleks.Data;
using Rybocompleks.Perepherial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers
{
    public class ActiveSensorsController : IActiveSensorsController
    {
        protected Controller<IActiveSensor> physicalObjectsController;
        public IGPAllowedStates CurrentInstruction{private get; set;}

        public ActiveSensorsController()
        {
            physicalObjectsController = new Controller<IActiveSensor>();
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            List<IShowInfo> ret = new List<IShowInfo>();
            IDictionary<MeasurmentTypes.Type, IActiveSensor> devices = physicalObjectsController.GetPhysicalObjects();

            foreach (IActiveSensor it in devices.Values)
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
