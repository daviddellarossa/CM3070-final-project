using System;
using System.Collections.Generic;
using System.Linq;
using FightShipArena.Assets.Scripts.Managers.Menus;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class Init : State
    {
        public readonly string _sceneName = "MainMenu";
        protected IMainMenuManager _menuManager;

        public Init(
            IGameManager gameManager, 
            IUnitySceneManagerWrapper sceneManagerWrapper
            ) : base(gameManager, sceneManagerWrapper) { }

        public override event EventHandler PauseGameEvent;
        public override event EventHandler ResumeGameEvent;
        public override event EventHandler PlayGameEvent;
        public override event EventHandler QuitCurrentGameEvent;
        public override event EventHandler QuitGameEvent;
        public override event EventHandler ShowCreditsEvent;
        public override event EventHandler ReturnToMainEvent;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="loadSceneMode"></param>
        public override void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            _menuManager = GetMenuManagerFromScene(scene);

            if (_menuManager == null)
                return;

            base.SceneLoaded(scene, loadSceneMode);

            _menuManager.StartGameEvent += StartGameEventHandler;
            _menuManager.QuitGameEvent += QuitGameEventHandler;
            _menuManager.ShowCreditsEvent += ShowCreditsEventHandler;
        }

        //This method is non-testable because it accesses Scene's methods and GameObject's methods, which are not mockable.
        protected virtual IMainMenuManager GetMenuManagerFromScene(Scene scene)
        {
            if (scene.name != _sceneName)
                return null;

            var rootGameObjects = scene.GetRootGameObjects();
            var sceneManagerGo = rootGameObjects.Single(x => x.name == "SceneManager");
            var menuManager = sceneManagerGo.GetComponent<MainMenuManager>();
            return menuManager;
        }

        protected virtual void StartGameEventHandler(object sender, EventArgs state)
        {
            PlayGameEvent?.Invoke(this, state);
        }

        protected virtual void QuitGameEventHandler(object sender, EventArgs state)
        {
            QuitGameEvent?.Invoke(this, state);
        }

        protected virtual void ShowCreditsEventHandler(object sender, EventArgs state)
        {
            ShowCreditsEvent?.Invoke(this, state);
        }

    }
}
