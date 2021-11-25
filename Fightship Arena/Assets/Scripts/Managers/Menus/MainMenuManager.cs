using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class MainMenuManager : MenuManager
    {
        public event EventHandler StartGameEvent;
        public event EventHandler QuitGameEvent;

        void Start()
        {
            Debug.Log($"Main menu opened");
        }

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
