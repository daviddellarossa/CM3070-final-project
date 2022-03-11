using FightShipArena.Assets.Scripts.Managers.EnemyManagement;
using FightShipArena.Assets.Scripts.Managers.OrchestrationManagement;
using FightShipArena.Assets.Scripts.Managers.ScoreManagement;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.Levels
{
    public interface ILevelManager : IMyMonoBehaviour
    {
        IPlayerControllerCore PlayerControllerCore { get; set; }
        IScoreManager ScoreManager { get; set; }
        IOrchestrationManager OrchestrationManager { get; set; }

        void OnStart();
        void OnAwake();
        void Move(InputAction.CallbackContext context);
        void DisablePlayerInput();
        void EnablePlayerInput();
    }
}