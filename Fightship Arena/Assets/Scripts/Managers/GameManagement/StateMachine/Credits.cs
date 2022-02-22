using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.Menus;
using FightShipArena.Assets.Scripts.Managers.SceneManagement;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class Credits : State
    {
        public readonly string _sceneName = "CreditsMenu";
        protected ICreditsMenuManager _menuManager;

        public Credits(
            IGameManager gameManager, 
            IUnitySceneManagerWrapper sceneManagerWrapper
            ) : base(gameManager, sceneManagerWrapper)
        { }

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

        public override void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            _menuManager = GetSceneManagerFromScene(scene);

            if (_menuManager == null)
                return;

            base.SceneLoaded(scene, loadSceneMode);

            //Bind event handlers here
            _menuManager.ReturnToMainEvent += _menuManager_ReturnToMainEvent; ;

        }

        private void _menuManager_ReturnToMainEvent(object sender, EventArgs state)
        {
            ReturnToMainEvent?.Invoke(this, state);
        }

        //This method is non-testable because it accesses Scene's methods and GameObject's methods, which are not mockable.
        protected virtual ICreditsMenuManager GetSceneManagerFromScene(Scene scene)
        {
            if (scene.name != _sceneName)
                return null;

            var rootGameObjects = scene.GetRootGameObjects();
            var sceneManagerGo = rootGameObjects.Single(x => x.name == "SceneManager");
            var levelManager = sceneManagerGo.GetComponent<CreditsMenuManager>();

            return levelManager;
        }

    }
}
