using FightShipArena.Assets.Scripts.Managers.HudManagement;
using FightShipArena.Assets.Scripts.Managers.OrchestrationManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.Levels.StateMachine
{
    public class StateConfiguration
    {
        public readonly ILevelManagerCore LevelManagerCore;
        public readonly IOrchestrationManager OrchestrationManager;
        public readonly IHudManager HudManager;
        public bool SpawnEnemiesEnabled;

        public StateConfiguration(
            ILevelManagerCore levelManagerCore,
            IOrchestrationManager orchestrationManager,
            IHudManager hudManager,
            bool spawnEnemiesEnabled = true)
        {
            LevelManagerCore = levelManagerCore;
            OrchestrationManager = orchestrationManager;
            HudManager = hudManager;
            SpawnEnemiesEnabled = spawnEnemiesEnabled;
        }

    }
}
