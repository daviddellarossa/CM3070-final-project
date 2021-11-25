using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.Menus;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class Pause : State
    {
        private readonly string _pauseMenuSceneName = "PauseMenu";
        private PauseMenuManager _menuManager;

        public Pause(GameManager gameManager) : base(gameManager) { }

        public override event EventHandler PauseGameEvent;
        public override event EventHandler ResumeGameEvent;
        public override event EventHandler PlayGameEvent;
        public override event EventHandler QuitCurrentGameEvent;
        public override event EventHandler QuitGameEvent;

        public override void OnEnter()
        {
            base.OnEnter();

            SceneManager.LoadSceneAsync(_pauseMenuSceneName, LoadSceneMode.Additive);
        }

        public override void OnExit()
        {
            base.OnExit();

            SceneManager.UnloadSceneAsync(_pauseMenuSceneName);
        }

        public override void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name != _pauseMenuSceneName)
                return;

            base.SceneLoaded(scene, loadSceneMode);

            var rootGameObjects = scene.GetRootGameObjects();
            var sceneManagerGo = rootGameObjects.Single(x => x.name == "SceneManager");
            _menuManager = sceneManagerGo.GetComponent<PauseMenuManager>();

            _menuManager.ResumeGameEvent += ResumeGameEventHandler;
            _menuManager.QuitCurrentGameEvent += QuitCurrentGameEventHandler;
        }

        private void ResumeGameEventHandler(object sender, EventArgs state)
        {
            ResumeGameEvent?.Invoke(this, new EventArgs());
        }

        private void QuitCurrentGameEventHandler(object sender, EventArgs state)
        {
            QuitCurrentGameEvent?.Invoke(this, new EventArgs());
        }

        public override void PauseResumeGame()
        {
            base.PauseResumeGame();

            ResumeGameEvent?.Invoke(this, new EventArgs());
        }
    }
}
