using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class HelpMenuManagerCore : IHelpMenuManager
    {
        public event EventHandler BackEvent;
        public event EventHandler<Sound> PlaySoundEvent;

        public readonly IMyMonoBehaviour Parent;

        public HelpMenuManagerCore(IMyMonoBehaviour parent)
        {
            Parent = parent;
        }
        public void BackToMainMenu()
        {
            BackEvent?.Invoke(this, new EventArgs());
        }

        public void OnAwake() { }

        public void OnStart()
        {
            Debug.Log($"Credits menu opened");
        }
    }
}
