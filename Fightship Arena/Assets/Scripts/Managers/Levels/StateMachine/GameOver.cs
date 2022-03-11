using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.Levels.StateMachine
{
    public class GameOver : State
    {
        public GameOver(StateConfiguration configuration) : base(configuration)
        {
        }

        public override event EventHandler<State> ChangeStateRequestEvent;

        public override void OnEnter()
        {
            base.OnEnter();
            Configuration.HudManager.SetCentralText("Game Over");
        }

        public override void OnExit()
        {
            base.OnExit();
            Configuration.HudManager.SetCentralText(String.Empty);
        }
    }
}
