using Rybocompleks.Data;
using Rybocompleks.GrowingPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.GrowingPlan
{    
    [Serializable]
    public class GrowingPlanList
    {        
        public List<GPInstruction> Instructions { get; set; }
        public GrowingPlanList()
        {
            Instructions = new List<GPInstruction>();
        }
    }
}
