using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using System;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public interface IPauseMenuManager
    {
        event EventHandler ResumeGameEvent;
        event EventHandler QuitCurrentGameEvent;
        event EventHandler<Sound> PlaySoundEvent;

        void OnStart();
        void OnAwake();
        void ResumeGame();
        void QuitCurrentGame();
    }
}