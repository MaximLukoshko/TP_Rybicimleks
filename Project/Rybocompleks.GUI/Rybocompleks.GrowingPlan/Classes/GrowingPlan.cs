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
    public class GrowingPlanList : IGrowingPlan
    {        
        public List<GPInstruction> Instructions { get; set; }
        public GrowingPlanList()
        {
            Instructions = new List<GPInstruction>();
        }

        public IDictionary<MeasurmentTypes.Type, IInstruction> GetAllowedStates(Int32 hours, Int32 minutes)
        {
            throw new NotImplementedException();
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
