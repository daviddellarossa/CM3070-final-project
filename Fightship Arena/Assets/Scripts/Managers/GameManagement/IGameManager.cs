using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement
{
    public interface IGameManager
    {
        void OnAwake();
        void OnStart();

        void OnPauseResumeGame(InputAction.CallbackContext context);
    }
}