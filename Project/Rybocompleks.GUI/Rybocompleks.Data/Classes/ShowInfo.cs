using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data
{
    public sealed class ShowInfo : IShowInfo
    {
        public IPhysicalObjectState State = null;

        public IPhysicalObject Item = null;

        public IPhysicalObjectState GetState()
        {
            return State;
        }

        public IPhysicalObject GetItem()
        {
            return Item;
        }
    }
}
