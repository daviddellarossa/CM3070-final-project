using System;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public interface IPauseMenuManager
    {
        event EventHandler ResumeGameEvent;
        event EventHandler QuitCurrentGameEvent;

        void OnStart();
        void OnAwake();
        void ResumeGame();
        void QuitCurrentGame();
    }
}