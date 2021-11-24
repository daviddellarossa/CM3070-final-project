using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.Menus;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class Init : State
    {
        public Init(GameManager gameManager) : base(gameManager) { }

        public override event EventHandler<State> ReplaceStateRequestEvent;
        public override event EventHandler<State> PushStateRequestEvent;

        public override void OnEnter()
        {
            base.OnEnter();
            SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        }

        public override void OnExit()
        {
            base.OnExit();
            SceneManager.UnloadSceneAsync("MainMenu");

        }

        public override void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            base.SceneLoaded(scene, loadSceneMode);

            var rootGameObjects = scene.GetRootGameObjects();
            var sceneManagerGo = rootGameObjects.Single(x => x.name == "SceneManager");
            var mainMenuManager = sceneManagerGo.GetComponent<MainMenuManager>();
            mainMenuManager.StartGameEvent += StartGameEventHandler;
            mainMenuManager.QuitGameEvent += QuitGameEventHandler;

        }

        private void StartGameEventHandler(object sender, EventArgs state)
        {
            ReplaceStateRequestEvent?.Invoke(this, new Play(this._gameManager));
        }

        private void QuitGameEventHandler(object sender, EventArgs state)
        {
            PushStateRequestEvent?.Invoke(this, new Quit(this._gameManager));
        }
    }
}
