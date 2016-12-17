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
        protected IList<IPhysObjType> devices;

        public Controller()
        {
            devices = new List<IPhysObjType>();
        }

        public ICollection<IShowInfo> GetShowInfo()
        {
            throw new NotImplementedException();
        }

        public void AddObject(IPhysObjType obj)
        {
            devices.Add(obj);
        }

        public IList<IPhysObjType> GetPhysicalObjects()
        {
            return devices;
        }
    }
}
