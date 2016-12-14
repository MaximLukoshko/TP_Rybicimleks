using Rybocompleks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybocompleks.Data
{
    public interface IGPAllowedStates
    {
        String Name { get; }
        Int32 Hours { get; }
        Int32 Minutes { get; }
        Double Progress { get; set; }
        IInstruction GetStateByPropertyID(MeasurmentTypes.Type id);
    }
}
