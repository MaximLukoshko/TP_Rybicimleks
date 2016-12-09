using Rybocompleks.Data;
using Rybocompleks.GrowingPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Dispatcher
{
    public class Dispatcher : IDispatcher
    {
        public Dispatcher(IGrowingPlan gp)
        {

        }

        public void RunFishGrowing()
        {
            throw new NotImplementedException();
        }

        public void StopFishGrowing()
        {
            throw new NotImplementedException();
        }

        public ICollection<ShowInfo> GetShowInfo()
        {
            throw new NotImplementedException();
        }

        private void MakeCycle()
        {
            throw new NotImplementedException();
        }
    }
}
