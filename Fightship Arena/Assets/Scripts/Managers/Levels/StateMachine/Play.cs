using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.Levels.StateMachine
{
    public class Play : State
    {
        public Play(StateConfiguration configuration) : base(configuration)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Configuration.LevelManagerCore.EnablePlayerInput();
            if (Configuration.SpawnEnemiesEnabled)
            {
                Configuration.OrchestrationManager.Run();
            }

        }

        public override void OnExit()
        {
            base.OnExit();

            Configuration.OrchestrationManager.Stop();
        }

        public override event EventHandler<State> ChangeStateRequestEvent;
    }
}
