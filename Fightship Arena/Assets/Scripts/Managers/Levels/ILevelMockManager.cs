using FightShipArena.Assets.Scripts.Managers.EnemyManagement;
using FightShipArena.Assets.Scripts.Managers.ScoreManagement;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.Levels
{
    public interface ILevelMockManager : IMyMonoBehaviour
    {
        IPlayerControllerCore PlayerControllerCore { get; set; }
        IScoreManager ScoreManager { get; set; }
        IEnemyManager EnemyManager { get; set; }

        void OnStart();
        void OnAwake();
        void Move(InputAction.CallbackContext context);
        void DisablePlayerInput();
        void EnablePlayerInput();
    }
}