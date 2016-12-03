using Rybocompleks.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers.Classes
{
    
    class Controller<IPhysObjType> where IPhysObjType : IPhysicalObject
    {
        protected IDictionary<Int32, IPhysObjType> devices;

        public Controller()
        {
            devices = new Dictionary<Int32, IPhysObjType>();
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            throw new NotImplementedException();
        }

        public void AddObject(IPhysObjType obj)
        {
            devices.Add(obj.GetPropertyID(), obj);
        }

        public IDictionary<Int32, IPhysObjType> GetPhysicalObjects()
        {
            return devices;
        }
    }
}
