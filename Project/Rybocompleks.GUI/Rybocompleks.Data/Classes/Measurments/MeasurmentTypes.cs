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
        public static String TypeToString(Type tp)
        {
            switch (tp)
            {
                case Type.Temperature:
                    return "Температура";
                case Type.PH:
                    return "Кислотность";
                case Type.Oxygen:
                    return "Кислород";
                case Type.LightPerDay:
                    return "Освещение";
                default:
                    return "Тип не определён";
            }
        }
    }
}
