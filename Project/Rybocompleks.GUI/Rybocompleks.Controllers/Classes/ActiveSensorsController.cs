using Perepherial.ActiveSensors;
using Rybocompleks.Data;
using Rybocompleks.Dispatcher;
using Rybocompleks.Perepherial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers
{
    public class ActiveSensorsController : IActiveSensorsController
    {
        protected Controller<IActiveSensor> physicalObjectsController;
        public IGPAllowedStates CurrentInstruction{private get; set;}
        private Thread MonitorSensorsThread;
        public IActiveSensorsControllerListener Listener;

        public ActiveSensorsController(IActiveSensorsControllerListener dispatcher)
        {
            physicalObjectsController = new Controller<IActiveSensor>();
            physicalObjectsController.AddObject(new ActiveTemperatureSensor(new Location(10, 20)));
            MonitorSensorsThread = new Thread(Monitor);
            MonitorSensorsThread.Start();
            Listener = dispatcher; 
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

        private void Monitor()
        {
            ICollection<IActiveSensor> actSensors= physicalObjectsController.GetPhysicalObjects().Values;
            IList<IMeasurment> dangerStates = new List<IMeasurment>();
            while(true)
            {
                Thread.Sleep(400);
                
                dangerStates.Clear();
                foreach(IActiveSensor actSens in actSensors)
                {
                    if (false == actSens.IsEnvironmentOK(CurrentInstruction.GetStateByPropertyID(actSens.GetPropertyID())))
                        dangerStates.Add(actSens.GetState());
                }

                if (dangerStates.Count > 0)
                    Listener.Notify(dangerStates);
            }
        }
    }
}
