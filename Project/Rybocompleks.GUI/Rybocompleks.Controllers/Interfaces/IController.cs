using Rybocompleks.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers.Interfaces
{
    interface IController
    {
        ICollection<IShowInfo> GetShowInfo();
    }
}
