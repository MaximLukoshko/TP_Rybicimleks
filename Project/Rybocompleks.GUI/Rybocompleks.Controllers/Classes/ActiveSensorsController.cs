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
        private IGPAllowedStates CurrentInstruction { get; set; }
        private Thread MonitorSensorsThread;
        public IActiveSensorsControllerListener Listener;

        public ActiveSensorsController(IActiveSensorsControllerListener dispatcher)
        {
            physicalObjectsController = new Controller<IActiveSensor>();
            physicalObjectsController.AddObject(new ActiveTemperatureSensor(new Location(80, 20)));
            MonitorSensorsThread = new Thread(Monitor);
            Listener = dispatcher; 
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            List<IShowInfo> ret = new List<IShowInfo>();
            IList<IActiveSensor> devices = physicalObjectsController.GetPhysicalObjects();

            foreach (IActiveSensor it in devices)
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
            ICollection<IActiveSensor> actSensors= physicalObjectsController.GetPhysicalObjects();
            IList<IMeasurment> dangerStates = new List<IMeasurment>();
            while(true)
            {
                Thread.Sleep(400);
                CurrentInstruction = Listener.GetCurrentInstruction();
                if (null == CurrentInstruction)
                    return;

                dangerStates.Clear();
                foreach(IActiveSensor actSens in actSensors)
                {
                    if (false == actSens.IsEnvironmentOK(CurrentInstruction.GetStateByPropertyID(actSens.GetPropertyID())))
                        dangerStates.Add(actSens.GetState());
                }

                if (dangerStates.Count > 0)
                {
                    Listener.Notify(dangerStates);
                    Thread.Sleep(1000); //Ждём пока состояние среды изменится
                }
            }
        }

        public void RunMonitoring()
        {
            MonitorSensorsThread.Start();
            Nature.EnvironmentThread.Start();   // Запускаем процесс изменения окружающей среды отсюда,
                                                // потому что изменение состояние среды никак не зависит от системы
        }

        public void StopMonitoring()
        {
            MonitorSensorsThread.Abort();
            Nature.EnvironmentThread.Abort();   // См. комментарий к "Nature.environmentThread.Start();"
            Nature.EnvironmentThread = null;    // Очищаем поток окружающей среды
        }
    }
}
