using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.GUI.Data
{
    class CurrentInstuctDescriptionTable
    {
        public string ParamName { get; set; }
        public string ParamValue { get; set; }

        public CurrentInstuctDescriptionTable()
        {
        }
        public CurrentInstuctDescriptionTable(string paramName, string paramValue)
        {
            ParamName = paramName;
            ParamValue = paramValue;
        }
    }
}
