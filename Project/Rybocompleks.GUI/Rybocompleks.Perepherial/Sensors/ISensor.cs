using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Perepherial
{
    public interface ISensor : IPhysicalObject
    {
        // Предполагается, что датчик измеряет состояние среды,
        // а потом хранит его до следующей итерации цикла
        IMeasurment Measure();
        IMeasurment GetLastMeasurment();
    }
}
