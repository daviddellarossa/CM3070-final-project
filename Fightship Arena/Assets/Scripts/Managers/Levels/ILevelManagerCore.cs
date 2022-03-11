using FightShipArena.Assets.Scripts.Player;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.Levels
{
    public interface ILevelManagerCore
    {
        IPlayerControllerCore PlayerControllerCore { get; set; }
        void OnStart();
        void OnAwake();
        void Move(InputAction.CallbackContext context);
        void DisablePlayerInput();
        void EnablePlayerInput();

    }
}