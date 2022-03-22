using FightShipArena.Assets.Scripts.Managers.Levels.StateMachine;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.Levels
{
    public interface ILevelManagerCore
    {
        State CurrentState { get;}
        ILevelManager LevelManager { get; set; }
        IPlayerControllerCore PlayerControllerCore { get; set; }
        void OnStart();
        void OnAwake();
        void Move(InputAction.CallbackContext context);
        void DisablePlayerInput();
        void EnablePlayerInput();

    }
}