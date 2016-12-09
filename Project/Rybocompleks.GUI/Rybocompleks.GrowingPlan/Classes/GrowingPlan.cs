using Rybocompleks.Data;
using Rybocompleks.Data;
using Rybocompleks.GrowingPlan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.GrowingPlan.Classes
{    
    [Serializable]
    public class GrowingPlanList : IGrowingPlan
    {        
        public List<GPInstruction> Instructions { get; set; }
        public GrowingPlanList()
        {
            Instructions = new List<GPInstruction>();
        }      
       /* public Dictionary<MeasurmentTypes.Type, IMeasurment> getAllowedStates()
        {
            Dictionary<MeasurmentTypes.Type ,IMeasurment> res = new Dictionary<MeasurmentTypes.Type,IMeasurment>();
            foreach(GPInstruction instruction in Instructions)
            {
                res.Add(MeasurmentTypes.Type.Oxygen, );

            }          
            return res;
        }
        */
    }
}
