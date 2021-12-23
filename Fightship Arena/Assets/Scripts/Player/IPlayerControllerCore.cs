using FightShipArena.Assets.Scripts.Enemies;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Player
{
    public interface IPlayerControllerCore
    {
        event System.Action<int> ScoreMultiplierCollected;

        IPlayerController Parent { get; }
        Transform Transform { get; }
        public IHealthManager HealthManager { get; }
        public PlayerSettings InitSettings { get; set; }
        Vector3 Movement { get; set; }
        void SetMovement(Vector2 movement);
        void Move();
        void StartFiring();
        void StopFiring();
        void FireAlt();
        void OpenSelectionMenu();
        void HandleCollisionWithEnemy(IEnemyControllerCore enemyController);

        void AddMultiplier(int multiplier);
    }
}