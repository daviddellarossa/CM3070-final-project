using FightShipArena.Assets.Scripts.Managers.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class Credits : State
    {
        public override event EventHandler PauseGameEvent;
        public override event EventHandler ResumeGameEvent;
        public override event EventHandler PlayGameEvent;
        public override event EventHandler QuitCurrentGameEvent;
        public override event EventHandler QuitGameEvent;
        public override event EventHandler CreditsEvent;
        public override event EventHandler BackToMainMenuEvent;

        public readonly string _sceneName = "CreditsMenu";
        protected ICreditsMenuManager _menuManager;

        public Credits(
            IGameManager gameManager, 
            IUnitySceneManagerWrapper sceneManagerWrapper
            ) : base(gameManager, sceneManagerWrapper)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            SceneManagerWrapper.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
            GameManager.SoundManager.PlayMusic(GameManager.SoundManager.MenuMusic);
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

            _menuManager.PlaySoundEvent += MenuManager_PlaySoundEvent;
            _menuManager.BackEvent += BackEventHandler;
        }

        private void MenuManager_PlaySoundEvent(object sender, SoundManagement.Sound e)
        {
            GameManager.SoundManager.PlaySound(e);
        }

        protected virtual ICreditsMenuManager GetMenuManagerFromScene(Scene scene)
        {
            if (scene.name != _sceneName)
                return null;

            var rootGameObjects = scene.GetRootGameObjects();
            var sceneManagerGo = rootGameObjects.Single(x => x.name == "SceneManager");
            var menuManager = sceneManagerGo.GetComponent<CreditsMenuManager>();
            return menuManager;
        }

        protected virtual void BackEventHandler(object sender, EventArgs state)
        {
            BackToMainMenuEvent?.Invoke(this, state);
        }

    }
}
