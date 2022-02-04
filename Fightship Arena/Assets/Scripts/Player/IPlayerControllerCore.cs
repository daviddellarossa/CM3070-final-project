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
        Rigidbody2D RigidBody { get; }
        public IHealthManager HealthManager { get; }
        public PlayerSettings InitSettings { get; set; }
        Vector2 PlayerInput { get; set; }
        void SetPlayerInput(Vector2 playerInput);
        void Move();
        void StartFiring();
        void StopFiring();
        void FireAlt();
        void OpenSelectionMenu();
        void HandleCollisionWithEnemy(IEnemyControllerCore enemyController);
        void TurnLeft();
        void TurnRight();
        void TurnUp();
        void TurnDown();
        void AddMultiplier(int multiplier);
    }
}