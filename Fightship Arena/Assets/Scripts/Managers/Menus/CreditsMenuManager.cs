using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class CreditsMenuManager : MenuManager, ICreditsMenuManager
    {
        public event EventHandler ReturnToMainEvent;

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

        public void OnStart()
        {
            Core.OnStart();
        }

        public void OnAwake()
        {
            Core.OnAwake();

            Core.ReturnToMainEvent += (sender, args) => ReturnToMainEvent?.Invoke(sender, args);
        }

        public void ReturnToMainMenu()
        {
            Core.ReturnToMainMenu();
        }
    }
}
