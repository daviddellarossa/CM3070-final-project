using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class HelpMenuManager : MenuManager, IHelpMenuManager
    {
        public event EventHandler BackEvent;
        public event EventHandler<Sound> PlaySoundEvent;

        public IHelpMenuManager Core { get; protected set; }

        void Awake()
        {
            Core = new HelpMenuManagerCore(this);

            OnAwake();
        }

        void Start()
        {
            OnStart();
        }

        public void BackToMainMenu()
        {
            BackEvent?.Invoke(this, new EventArgs());
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

        public override void PlaySound(Sound sound)
        {
            PlaySoundEvent?.Invoke(this, sound);
        }
    }
}
