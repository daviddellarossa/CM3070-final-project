using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class PauseMenuManager : MenuManager, IPauseMenuManager
    {
        public event EventHandler ResumeGameEvent;
        public event EventHandler QuitCurrentGameEvent;

        public IPauseMenuManager Core { get; protected set; }

        private float _timeScale;

        void Awake()
        {
            Core = new PauseMenuManagerCore(this);

            OnAwake();
        }

        void Start()
        {
            OnStart();
        }

        public void OnStart()
        {
            Core.OnStart();
            _timeScale = Time.timeScale;
            SetTimeScale();
        }

        public void OnAwake()
        {
            Core.OnAwake();

            Core.ResumeGameEvent += (sender, args) => ResumeGameEvent?.Invoke(sender, args);
            Core.QuitCurrentGameEvent += (sender, args) => QuitCurrentGameEvent?.Invoke(sender, args);
        }

        public void ResumeGame()
        {
            Core.ResumeGame();
            ResetTimeScale();
        }

        public void QuitCurrentGame()
        {
            Core.QuitCurrentGame();
            ResetTimeScale();
        }

        private void SetTimeScale()
        {
            Time.timeScale = 0;
        }
        private void ResetTimeScale()
        {
            Time.timeScale = _timeScale;
        }
    }
}
