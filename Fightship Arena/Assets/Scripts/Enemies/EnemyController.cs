﻿using FightShipArena.Assets.Scripts.Managers.HealthManagement;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public abstract class EnemyController : MyMonoBehaviour
    {
        public EnemySettings InitSettings;
        public IEnemyControllerCore Core { get; set; }
        public IHealthManager HealthManager { get; set; }

    }
}