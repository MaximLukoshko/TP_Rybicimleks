using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data.Classes
{
    public class Location
    {
        public Location(Int32 x, Int32 y)
        {
            this.X = x;
            this.Y = y;
        }
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
    }
}