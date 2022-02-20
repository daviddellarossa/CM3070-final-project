using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class MainMenuManager : MenuManager, IMainMenuManager
    {
        public event EventHandler StartGameEvent;
        public event EventHandler QuitGameEvent;

        public IMainMenuManager Core { get; protected set; }

        void Awake()
        {
            Core = new MainMenuManagerCore(this);

            OnAwake();
        }
        void Start()
        {
            OnStart();
        }

        public void OnStart()
        {
            Core.OnStart();
        }

        public void OnAwake()
        {
            Core.OnAwake();

            Core.QuitGameEvent += (sender, args) => QuitGameEvent?.Invoke(sender, args);
            Core.StartGameEvent += (sender, args) => StartGameEvent?.Invoke(sender, args);
        }

        public void StartGame()
        {
            Core.StartGame();
        }

        public void QuitGame()
        { 
            Core.QuitGame();
        }

        public void ShowCredits()
        {
            Core.ShowCredits();
        }
    }
}
