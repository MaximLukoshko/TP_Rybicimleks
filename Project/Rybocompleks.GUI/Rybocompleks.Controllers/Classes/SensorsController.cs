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
    public class SensorsController : ISensorsController
    {
        protected Controller<ISensor> physicalObjectsController;
        public SensorsController()
        {
            physicalObjectsController = new Controller<ISensor>();
        }

        public IDictionary<MeasurmentTypes.Type, IMeasurment> GetEnvironmentStates()
        {
            IDictionary<MeasurmentTypes.Type, IMeasurment> ret = new Dictionary<MeasurmentTypes.Type, IMeasurment>();
            IDictionary<MeasurmentTypes.Type, ISensor> sensors = physicalObjectsController.GetPhysicalObjects();

            foreach (ISensor sens in sensors.Values)
                ret.Add(sens.GetPropertyID(), sens.Measure());

            return ret;
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            List<IShowInfo> ret = new List<IShowInfo>();
            IDictionary<MeasurmentTypes.Type, ISensor> sensors = physicalObjectsController.GetPhysicalObjects();

            foreach (ISensor it in sensors.Values)
            {
                ShowInfo shInf = new ShowInfo();
                shInf.State = it.GetLastMeasurment();
                shInf.Item = it;
                ret.Add(shInf);
            }

            return ret;
        }
    }
}
