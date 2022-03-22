using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using System;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class CreditsMenuManagerCore : ICreditsMenuManager
    {
        public event EventHandler BackEvent;
        public event EventHandler<Sound> PlaySoundEvent;

        public readonly IMyMonoBehaviour Parent;

        public CreditsMenuManagerCore(IMyMonoBehaviour parent)
        {
            Parent = parent;
        }

        public void OnAwake() { }

        public void OnStart()
        {
            Debug.Log($"Credits menu opened");
        }

        public void BackToMainMenu()
        {
            BackEvent?.Invoke(this, new EventArgs());
        }
    }
}
