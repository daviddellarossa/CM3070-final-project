using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.Levels.StateMachine
{
    public class Win : State
    {
        public override event EventHandler<State> ChangeStateRequestEvent;
        private float _returnToMainDelay = 8;
        public Win(StateConfiguration configuration) : base(configuration)
        {

        }
        public override void OnEnter()
        {
            base.OnEnter();
            Configuration.HudManager.SetCentralText("You Won!");
            Configuration.LevelManagerCore.DisablePlayerInput();
            Configuration.LevelManagerCore.LevelManager.ScoreManager.AddToHighScore();
            Configuration.LevelManagerCore.LevelManager.StartCoroutine(CoReturnToMain());
        }

        public IEnumerator CoReturnToMain()
        {
            yield return new WaitForSeconds(_returnToMainDelay);
            Configuration.LevelManagerCore.LevelManager.ReturnToMain();
        }

        public override void OnExit()
        {
            base.OnExit();
            Configuration.HudManager.SetCentralText(String.Empty);
        }

    }
}
