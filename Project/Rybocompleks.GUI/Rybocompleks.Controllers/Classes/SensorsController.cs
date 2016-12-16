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
            physicalObjectsController.AddObject(new TemperatureSensor(new Location(50, 10)));
            physicalObjectsController.AddObject(new TemperatureSensor(new Location(80, 50)));
            physicalObjectsController.AddObject(new OxygenSensor(new Location(50, 30)));
            physicalObjectsController.AddObject(new PhSensor(new Location(50, 60)));
            physicalObjectsController.AddObject(new LightSensor(new Location(50, 80)));
        }

        public IList<IMeasurment> GetEnvironmentStates()
        {
            IList<IMeasurment> ret = new List<IMeasurment>();
            IList<ISensor> sensors = physicalObjectsController.GetPhysicalObjects();

            foreach (ISensor sens in sensors)
                ret.Add(sens.Measure());

            return ret;
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            List<IShowInfo> ret = new List<IShowInfo>();
            IList<ISensor> sensors = physicalObjectsController.GetPhysicalObjects();

            foreach (ISensor it in sensors)
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
