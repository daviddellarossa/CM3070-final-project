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
        public readonly string _sceneName = "LevelMock";
        protected ILevelMockManager _levelManager;

        public Play(
            IGameManager gameManager,
            IUnitySceneManagerWrapper sceneManagerWrapper
        ) : base(gameManager, sceneManagerWrapper) { }

        public override event EventHandler PauseGameEvent;
        public override event EventHandler ResumeGameEvent;
        public override event EventHandler PlayGameEvent;
        public override event EventHandler QuitCurrentGameEvent;
        public override event EventHandler QuitGameEvent;

        public override void OnEnter()
        {
            base.OnEnter();

            SceneManagerWrapper.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
        }

        public override void OnExit()
        {
            base.OnExit();

            SceneManagerWrapper.UnloadSceneAsync(_sceneName);
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
            _levelManager = GetSceneManagerFromScene(scene);

            if (_levelManager == null)
                return;

            base.SceneLoaded(scene, loadSceneMode);

            //Bind event handlers here
        }

        //This method is non-testable because it accesses Scene's methods and GameObject's methods, which are not mockable.
        protected virtual ILevelMockManager GetSceneManagerFromScene(Scene scene)
        {
            if (scene.name != _sceneName)
                return null;

            var rootGameObjects = scene.GetRootGameObjects();
            var sceneManagerGo = rootGameObjects.Single(x => x.name == "SceneManager");
            var levelManager = sceneManagerGo.GetComponent<LevelMockManager>();

            return levelManager;
        }


        public override void PauseResumeGame()
        {
            base.PauseResumeGame();

            PauseGameEvent?.Invoke(this, new EventArgs());
        }

    }
}
