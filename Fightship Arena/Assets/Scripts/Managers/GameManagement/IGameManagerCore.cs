using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement
{
    public interface IGameManagerCore
    {
        void OnAwake();
        void OnStart();

        void OnPauseResumeGame(InputAction.CallbackContext context);
    }
}