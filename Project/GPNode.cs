using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.GUI
{
    [Serializable]
    public class GPNode
    {
        public string stageName { get; set; }
        public int houres { get; set; }
        public int minutes { get; set; }
        public int temperature { get; set; }
        public int oxygen { get; set; }
        public int LightPerDay { get; set; }
        public int pH { get; set; }
        public GPNode(){}
        public GPNode(string stageName = "имя интсрукции", int houres = 0, int minutes = 0, 
            int temperature = 25, int oxygen = 20, int LightPerDay = 12, int pH = 7)
        {
           this.stageName = stageName;
           this.houres = houres;
           this.minutes = minutes;
           this.temperature = temperature;
           this.oxygen = oxygen;
           this.LightPerDay = LightPerDay;
           this.pH = pH; 
        }
    }
}
