using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class MainMenuManager : SceneManagement.SceneManager
    {
        public event EventHandler StartGameEvent;
        public event EventHandler QuitGameEvent;

        public void StartGame()
        {
            StartGameEvent?.Invoke(this, new EventArgs());
        }

        public void QuitGame()
        { 
            QuitGameEvent?.Invoke(this, new EventArgs());
        }

    }
}
