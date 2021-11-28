using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class PauseMenuManagerCore : IPauseMenuManager
    {
        public event EventHandler ResumeGameEvent;
        public event EventHandler QuitCurrentGameEvent;

        public readonly IMyMonoBehaviour Parent;

        public PauseMenuManagerCore(IMyMonoBehaviour parent)
        {
            Parent = parent;
        }
        public void OnStart()
        {
            Debug.Log($"Pause menu opened");
        }

        public void OnAwake() { }

        public void ResumeGame()
        {
            ResumeGameEvent?.Invoke(this, new EventArgs());
        }

        public void QuitCurrentGame()
        {
            QuitCurrentGameEvent?.Invoke(this, new EventArgs());
        }
    }
}
