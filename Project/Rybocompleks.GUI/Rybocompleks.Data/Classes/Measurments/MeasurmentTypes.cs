using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data
{
    static public class MeasurmentTypes
    {
        public enum Type
        {          
            DefaultType      = 0,
            Temperature      = 1,
            Oxygen           = 2, 
            LightPerDay      = 3,
            PH               = 4,
        }
    }
}
