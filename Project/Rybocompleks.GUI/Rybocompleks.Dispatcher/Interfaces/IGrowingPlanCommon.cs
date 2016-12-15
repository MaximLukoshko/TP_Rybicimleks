using Rybocompleks.Data;
using Rybocompleks.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Dispatcher
{
    public interface IGrowingPlanCommon
    {
        IGPAllowedStates GetAllowedStates(Int32 hours, Int32 minutes);
    }
}
