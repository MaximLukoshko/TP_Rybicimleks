using Rybocompleks.Data;
using System.Collections.Generic;

namespace Rybocompleks.Dispatcher
{
    public interface IDispatcher
    {
        void RunFishGrowing();
        void StopFishGrowing();
        ICollection<ShowInfo> GetShowInfo();
    }
}
