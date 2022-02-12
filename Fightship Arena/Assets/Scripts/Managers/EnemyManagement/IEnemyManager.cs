using System;
using System.Collections.Generic;
using FightShipArena.Assets.Scripts.Enemies;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.EnemyManagement
{
    [Obsolete("Use OrchestrationManager instead")]
    public interface IEnemyManager : IMyMonoBehaviour
    {
        event Action<int> SendScore;

        List<IEnemyControllerCore> Enemies { get; set; }
        void SpawnPawnAtPlayerCommand(InputAction.CallbackContext context);

        void StartSpawing();
        void StopSpawning();
        void EnemySpawned(GameObject obj);
    }
}