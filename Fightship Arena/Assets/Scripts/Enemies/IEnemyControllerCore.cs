using FightShipArena.Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public interface IEnemyControllerCore
    {
        IPlayerControllerCore PlayerControllerCore { get; set; }
        IMyMonoBehaviour Parent { get; }
        Transform Transform { get; } 
        EnemySettings EnemySettings { get; }
        int Health { get; set; }

        void Start(EnemySettings settings);
        void FixedUpdate();
    }
}
