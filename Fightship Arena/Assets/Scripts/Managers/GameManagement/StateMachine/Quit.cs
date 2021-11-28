using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class Quit : State
    {
        public Quit(
            IGameManager gameManager,
            IUnitySceneManagerWrapper sceneManagerWrapper
        ) : base(gameManager, sceneManagerWrapper) { }

        public override event EventHandler PauseGameEvent;
        public override event EventHandler ResumeGameEvent;
        public override event EventHandler PlayGameEvent;
        public override event EventHandler QuitCurrentGameEvent;
        public override event EventHandler QuitGameEvent;

        public override void OnActivate()
        {
            base.OnActivate();

            Application.Quit();
        }

    }
}
