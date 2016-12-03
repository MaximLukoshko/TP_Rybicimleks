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
        private string stageName;
        public string StageName
        {
            get
            {
                return stageName;
            }
            set
            {
                if(value == null)
                {
                    stageName = "";
                }
                else
                {
                    stageName = value;
                }
            }
        }

        private int houres;
        public int Houres
        {
            get
            {
                return houres;
            }

            set
            {
                if (value >= 0)
                {
                    houres = value;
                }
                else
                {
                    houres = 0;
                }
            }
        }

        private int minutes;
        public int Minutes
        {
            get
            {
                return minutes;
            }

            set
            {
                if ((value >= 0) && (value < 60))
                {
                    minutes = value;
                }
                else
                {
                    minutes = 0;
                }
            }
        }
        
        private int temperature=25;
        public int Temperature { 
            get
            {
                return temperature;
            }
            
            set
            {
                if ((value > 0) && (value < 100))
                {
                    temperature = value;
                }
                else
                {
                    temperature = 25;
                }
            }
        }

        private int oxygen;
        public int Oxygen{ 
            get
            {
                return oxygen;
            }
            
            set
            {
                if (value >= 0)
                {
                    oxygen = value;
                }
                else
                {
                    oxygen = 0;
                }
            }
        }
        
        private int lightPerDay;
        public int LightPerDay
        {
            get
            {
                return lightPerDay;
            }
            set
            {
                if ((value >= 0) && (value <=24 ))
                {
                    lightPerDay = value;
                }
                else
                {
                    lightPerDay = 0;
                }
            }
        }

        public double ph;
        public double PH
        {
            get
            {
                return ph;
            }

            set
            {
                if ((value >= 0) && (value <=20))
                {
                    ph = value;
                }
                else
                {
                    ph = 7;
                }
            }
        }
        
        public GPNode(){}
        public GPNode(string stageName = "имя интсрукции", int houres = 0, int minutes = 0, 
            int temperature = 25, int oxygen = 20, int LightPerDay = 12, int pH = 7)
        {
           this.StageName = stageName;
           this.Houres = houres;
           this.Minutes = minutes;
           this.Temperature = temperature;
           this.Oxygen = oxygen;
           this.LightPerDay = LightPerDay;
           this.PH = pH; 
        }
        public GPNode(GPNode gpn)
        {
            this.StageName = gpn.StageName;
            this.Houres = gpn.Houres;
            this.Minutes = gpn.Minutes;
            this.Temperature = gpn.Temperature;
            this.Oxygen = gpn.Oxygen;
            this.LightPerDay = gpn.LightPerDay;
            this.PH = gpn.PH;
        }
    }
}
