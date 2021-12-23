using System;
using System.Collections.Generic;
using FightShipArena.Assets.Scripts.Enemies;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.EnemyManagement
{
    public interface IEnemyManager : IMyMonoBehaviour
    {
        event Action<int> SendScore;

        List<IEnemyControllerCore> Enemies { get; set; }
        void SpawnPawnAtRandomLocation(InputAction.CallbackContext context);
    }
}