using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using System;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class MainMenuManagerCore : IMainMenuManager
    {
        public event EventHandler StartGameEvent;
        public event EventHandler QuitGameEvent;
        public event EventHandler<Sound> PlaySoundEvent;
        public event EventHandler CreditsEvent;
        public event EventHandler HelpEvent;

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
            CreditsEvent?.Invoke(this, new EventArgs());
        }

        public void ShowHelp()
        {
            HelpEvent?.Invoke(this, new EventArgs());
        }
    }
}
