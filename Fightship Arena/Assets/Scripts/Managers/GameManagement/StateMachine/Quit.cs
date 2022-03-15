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
        public override event EventHandler PauseGameEvent;
        public override event EventHandler ResumeGameEvent;
        public override event EventHandler PlayGameEvent;
        public override event EventHandler QuitCurrentGameEvent;
        public override event EventHandler QuitGameEvent;
        public override event EventHandler CreditsEvent;
        public override event EventHandler BackToMainMenuEvent;
        public override event EventHandler HelpEvent;

        public Quit(
            IGameManager gameManager,
            IUnitySceneManagerWrapper sceneManagerWrapper
        ) : base(gameManager, sceneManagerWrapper) { }

        public override void OnActivate()
        {
            base.OnActivate();

        }

    }
}
