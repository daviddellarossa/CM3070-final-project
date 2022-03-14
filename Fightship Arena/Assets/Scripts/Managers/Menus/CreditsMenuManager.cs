using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using System;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class CreditsMenuManager : MenuManager, ICreditsMenuManager
    {
        public event EventHandler BackEvent;
        public event EventHandler<Sound> PlaySoundEvent;

        public ICreditsMenuManager Core { get; protected set; }
        
        void Awake()
        {
            Core = new CreditsMenuManagerCore(this);

            OnAwake();
        }

        void Start()
        {
            OnStart();
        }

        public void OnAwake()
        {
            Core.OnAwake();
            Core.BackEvent += (sender, args) => BackEvent?.Invoke(sender, args);
        }

        public void OnStart()
        {
            Core.OnStart();
        }

        public void BackToMainMenu()
        {
            BackEvent?.Invoke(this, new EventArgs());
        }
        public override void PlaySound(Sound sound)
        {
            PlaySoundEvent?.Invoke(this, sound);
        }

    }
}
