using FightShipArena.Assets.Scripts.Managers.SoundManagement;
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
        public event EventHandler<Sound> PlaySoundEvent;
        public event EventHandler CreditsEvent;

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
            Core.CreditsEvent += (sender, args) => CreditsEvent?.Invoke(sender, args);
        }

        public void StartGame()
        {
            Core.StartGame();
        }

        public void QuitGame()
        { 
            Core.QuitGame();
        }

        public override void PlaySound(Sound sound)
        {
            PlaySoundEvent?.Invoke(this, sound);
        }

        public void ShowCredits()
        {
            Core.ShowCredits();
        }
    }
}
