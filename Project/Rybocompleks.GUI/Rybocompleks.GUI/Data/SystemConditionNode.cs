using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.GUI.Data
{
    class SystemConditionNode
    {
        public SystemConditionNode(){}
        public SystemConditionNode(string elementName, string elementState)
        {
            ElementName = elementName;
            ElementState = elementState;
        }
        public string ElementName { get; private set; }
        public string ElementState { get; private set; }

    }
}
