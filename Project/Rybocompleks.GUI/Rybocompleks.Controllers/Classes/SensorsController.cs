﻿using Perepherial.Sensors;
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
    class SensorsController : ISensorsController
    {
        protected Controller<ISensor> physicalObjectsController;
        public SensorsController()
        {
            physicalObjectsController = new Controller<ISensor>();
        }

        public IDictionary<Int32, IMeasurment> GetEnvironmentStates()
        {
            IDictionary<Int32, IMeasurment> ret = new Dictionary<Int32, IMeasurment>();
            IDictionary<Int32, ISensor> sensors = physicalObjectsController.GetPhysicalObjects();

            foreach (ISensor sens in sensors.Values)
                ret.Add(sens.GetPropertyID(), sens.Measure());

            return ret;
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            List<IShowInfo> ret = new List<IShowInfo>();
            IDictionary<Int32, ISensor> sensors = physicalObjectsController.GetPhysicalObjects();

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