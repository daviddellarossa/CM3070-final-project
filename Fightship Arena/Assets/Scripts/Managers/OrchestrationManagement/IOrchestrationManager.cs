using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    public interface IOrchestrationManager
    {
        event Action<int> SendScore;
        event Action OrchestrationComplete;

        void Run();
        void Stop();
    }
}
