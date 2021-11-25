using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class PauseMenuManager : MenuManager
    {
        public event EventHandler ResumeGameEvent;
        public event EventHandler QuitCurrentGameEvent;

        void Start()
        {
            Debug.Log($"Pause menu opened");
        }

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
