using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using System;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public interface IMainMenuManager
    {
        event EventHandler StartGameEvent;
        event EventHandler CreditsEvent;
        event EventHandler QuitGameEvent;
        event EventHandler<Sound> PlaySoundEvent;
        event EventHandler HelpEvent;

        void OnStart();
        void OnAwake();
        void StartGame();
        void ShowCredits();
        void QuitGame();
        void ShowHelp();
    }
}