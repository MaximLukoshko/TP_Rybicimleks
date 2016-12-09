using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Controllers
{
    interface IController
    {
        ICollection<IShowInfo> GetShowInfo();
    }
}
