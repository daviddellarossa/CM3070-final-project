using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement
{
    public interface IGameManager
    {
        ISoundManager SoundManager { get; }

        void OnAwake();
        void OnStart();

        void OnPauseResumeGame(InputAction.CallbackContext context);
    }
}