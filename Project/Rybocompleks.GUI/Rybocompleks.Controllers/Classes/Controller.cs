using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers
{
    
    public class Controller<IPhysObjType> where IPhysObjType : IPhysicalObject
    {
        protected IDictionary<MeasurmentTypes.Type, IPhysObjType> devices;

        public Controller()
        {
            devices = new Dictionary<MeasurmentTypes.Type, IPhysObjType>();
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            throw new NotImplementedException();
        }

        public void AddObject(IPhysObjType obj)
        {
            devices.Add(obj.GetPropertyID(), obj);
        }

        public IDictionary<MeasurmentTypes.Type, IPhysObjType> GetPhysicalObjects()
        {
            return devices;
        }
    }
}
