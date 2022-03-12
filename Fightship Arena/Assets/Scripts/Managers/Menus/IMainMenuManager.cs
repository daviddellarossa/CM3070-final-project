using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using System;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public interface IMainMenuManager
    {
        event EventHandler StartGameEvent;
        event EventHandler QuitGameEvent;
        event EventHandler<Sound> PlaySoundEvent;

        void OnStart();
        void OnAwake();
        void StartGame();
        void QuitGame();
    }
}