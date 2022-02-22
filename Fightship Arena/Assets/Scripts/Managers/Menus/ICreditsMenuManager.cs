using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public interface ICreditsMenuManager
    {
        event EventHandler ReturnToMainEvent;
        void OnStart();
        void OnAwake();
        void ReturnToMainMenu();

    }
}
