using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.Levels;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class Play : State
    {
        private readonly string _levelMockSceneName = "LevelMock";
        private LevelManager _levelManager;

        public Play(GameManagerCore gameManager) : base(gameManager) { }

        public override event EventHandler PauseGameEvent;
        public override event EventHandler ResumeGameEvent;
        public override event EventHandler PlayGameEvent;
        public override event EventHandler QuitCurrentGameEvent;
        public override event EventHandler QuitGameEvent;

        public override void OnEnter()
        {
            base.OnEnter();

            SceneManager.LoadSceneAsync(_levelMockSceneName, LoadSceneMode.Additive);
        }

        public override void OnExit()
        {
            base.OnExit();

            SceneManager.UnloadSceneAsync(_levelMockSceneName);
        }

        public override void OnActivate()
        {
            base.OnActivate();

            _levelManager?.EnablePlayerInput();
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();

            _levelManager?.DisablePlayerInput();
        }

        public override void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name != _levelMockSceneName)
                return;

            base.SceneLoaded(scene, loadSceneMode);

            var rootGameObjects = scene.GetRootGameObjects();
            var sceneManagerGo = rootGameObjects.Single(x => x.name == "SceneManager");
            _levelManager = sceneManagerGo.GetComponent<LevelManager>();

            //Bind event handlers here
        }

        public override void PauseResumeGame()
        {
            base.PauseResumeGame();

            PauseGameEvent?.Invoke(this, new EventArgs());
        }

    }
}
