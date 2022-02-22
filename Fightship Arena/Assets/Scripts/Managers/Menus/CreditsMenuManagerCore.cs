using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class CreditsMenuManagerCore : ICreditsMenuManager
    {
        public event EventHandler ReturnToMainEvent;

        public readonly IMyMonoBehaviour Parent;

        public CreditsMenuManagerCore(IMyMonoBehaviour parent)
        {
            Parent = parent;
        }
        public void OnStart()
        {
            Debug.Log($"Credits menu opened");
        }

        public void OnAwake() { }

        public void ReturnToMainMenu()
        {
            ReturnToMainEvent?.Invoke(this, new EventArgs());
        }
    }
}
