using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.Menus;
using PlasticGui.WorkspaceWindow;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class Init : State
    {
        private readonly string _mainMenuSceneName = "MainMenu";
        private MainMenuManager _menuManager;

        public Init(GameManager gameManager) : base(gameManager) { }

        public override event EventHandler PauseGameEvent;
        public override event EventHandler ResumeGameEvent;
        public override event EventHandler PlayGameEvent;
        public override event EventHandler QuitCurrentGameEvent;
        public override event EventHandler QuitGameEvent;

        public override void OnEnter()
        {
            base.OnEnter();

            SceneManager.LoadSceneAsync(_mainMenuSceneName, LoadSceneMode.Additive);
        }

        public override void OnExit()
        {
            base.OnExit();

            SceneManager.UnloadSceneAsync(_mainMenuSceneName);
        }

        public override void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name != _mainMenuSceneName)
                return;

            base.SceneLoaded(scene, loadSceneMode);

            var rootGameObjects = scene.GetRootGameObjects();
            var sceneManagerGo = rootGameObjects.Single(x => x.name == "SceneManager");
            _menuManager = sceneManagerGo.GetComponent<MainMenuManager>();

            _menuManager.StartGameEvent += StartGameEventHandler;
            _menuManager.QuitGameEvent += QuitGameEventHandler;
        }

        private void StartGameEventHandler(object sender, EventArgs state)
        {
            PlayGameEvent?.Invoke(this, new EventArgs());
        }

        private void QuitGameEventHandler(object sender, EventArgs state)
        {
            QuitGameEvent?.Invoke(this, new EventArgs());
        }
    }
}
