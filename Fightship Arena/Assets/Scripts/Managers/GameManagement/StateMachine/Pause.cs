using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.Menus;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class Pause : State
    {
        public readonly string _sceneName = "PauseMenu";
        protected IPauseMenuManager _menuManager;

        public Pause(
            IGameManager gameManager,
            IUnitySceneManagerWrapper sceneManagerWrapper
        ) : base(gameManager, sceneManagerWrapper) { }

        public override event EventHandler PauseGameEvent;
        public override event EventHandler ResumeGameEvent;
        public override event EventHandler PlayGameEvent;
        public override event EventHandler QuitCurrentGameEvent;
        public override event EventHandler QuitGameEvent;

        private float _timeScale;

        public override void OnEnter()
        {
            base.OnEnter();

            _timeScale = Time.timeScale;
            SetTimeScale();

            SceneManagerWrapper.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
            GameManager.SoundManager.PlayMusic(GameManager.SoundManager.MenuMusic);

        }

        public override void OnExit()
        {
            base.OnExit();

            SceneManagerWrapper.UnloadSceneAsync(_sceneName);

            ResetTimeScale();
        }

        public override void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            _menuManager = GetMenuManagerFromScene(scene);

            if (_menuManager == null)
                return;

            base.SceneLoaded(scene, loadSceneMode);

            _menuManager.PlaySoundEvent += MenuManager_PlaySoundEvent;
            _menuManager.ResumeGameEvent += ResumeGameEventHandler;
            _menuManager.QuitCurrentGameEvent += QuitCurrentGameEventHandler;
        }

        private void MenuManager_PlaySoundEvent(object sender, SoundManagement.Sound e)
        {
            GameManager.SoundManager.PlaySound(e);
        }

        //This method is non-testable because it accesses Scene's methods and GameObject's methods, which are not mockable.
        protected virtual IPauseMenuManager GetMenuManagerFromScene(Scene scene)
        {
            if (scene.name != _sceneName)
                return null;

            var rootGameObjects = scene.GetRootGameObjects();
            var sceneManagerGo = rootGameObjects.Single(x => x.name == "SceneManager");
            var menuManager = sceneManagerGo.GetComponent<PauseMenuManager>();
            return menuManager;
        }


        protected void ResumeGameEventHandler(object sender, EventArgs state)
        {
            ResumeGameEvent?.Invoke(this, new EventArgs());
        }

        protected void QuitCurrentGameEventHandler(object sender, EventArgs state)
        {
            QuitCurrentGameEvent?.Invoke(this, new EventArgs());
        }

        public override void PauseResumeGame()
        {
            base.PauseResumeGame();

            ResumeGameEvent?.Invoke(this, new EventArgs());
        }
        private void SetTimeScale()
        {
            Time.timeScale = 0;
        }
        private void ResetTimeScale()
        {
            Time.timeScale = _timeScale;
        }

    }
}
