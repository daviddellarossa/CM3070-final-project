using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class MainMenuManagerCore : IMainMenuManager
    {
        public event EventHandler StartGameEvent;
        public event EventHandler QuitGameEvent;

        public readonly IMyMonoBehaviour Parent;

        public MainMenuManagerCore(IMyMonoBehaviour parent)
        {
            Parent = parent;
        }
        public void OnStart()
        {
            Debug.Log($"Main menu opened");
        }

        public void OnAwake() { }

        public void StartGame()
        {
            StartGameEvent?.Invoke(this, new EventArgs());
        }

        public void QuitGame()
        {
            QuitGameEvent?.Invoke(this, new EventArgs());
        }

        public void ShowCredits()
        {
            
        }
    }
}
