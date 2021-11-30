using System;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public interface IMainMenuManager
    {
        event EventHandler StartGameEvent;
        event EventHandler QuitGameEvent;

        void OnStart();
        void OnAwake();
        void StartGame();
        void QuitGame();
    }
}