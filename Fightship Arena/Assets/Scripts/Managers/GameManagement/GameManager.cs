using System.Collections.Generic;
using System.Linq;
using FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine;
using FightShipArena.Assets.Scripts.Managers.Levels;
using FightShipArena.Assets.Scripts.Managers.Menus;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement
{
    public class GameManager : MyMonoBehaviour
    {
        public IGameManagerCore Core { get; private set; }

        private StateStack _stateStack = new StateStack();

        private Scene CurrentScene;
        private Scene MenuScene;

        void Awake()
        {
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
            SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;

            Core = new GameManagerCore(this);
        }
        // Start is called before the first frame update
        void Start()
        {
            State_PushStateRequestEvent(this, new Init(this));
        }

        private void State_ReplaceStateRequestEvent(object sender, State state)
        {
            var prevState = _stateStack.Pop();

            prevState.PushStateRequestEvent -= State_PushStateRequestEvent;
            prevState.ReplaceStateRequestEvent -= State_ReplaceStateRequestEvent;

            State_PushStateRequestEvent(sender, state);
        }

        private void State_PushStateRequestEvent(object sender, State state)
        {
            _stateStack.Push(state);

            state.PushStateRequestEvent += State_PushStateRequestEvent;
            state.ReplaceStateRequestEvent += State_ReplaceStateRequestEvent;
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        public void PauseResumeGame(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    Debug.Log($"{context.action} Performed");
                    if (MenuScene != default)
                    {
                        ResumeGame(context);
                    }
                    else
                    {
                        PauseGame(context);
                    }
                    break;
            }
        }
        public void PauseGame(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    Debug.Log($"{context.action} Performed");

                    if (CurrentScene != default)
                    {
                        var sceneManagerGo = CurrentScene.GetRootGameObjects().Single(x => x.tag == "SceneManager");
                        var sceneManager = sceneManagerGo.GetComponent<LevelMockManager>();
                        sceneManager.DisablePlayerInput();
                    }
                    SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);

                    break;
            }
        }

        public void ResumeGame(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    Debug.Log($"{context.action} Performed");

                    if (CurrentScene != default)
                    {
                        var sceneManagerGo = CurrentScene.GetRootGameObjects().Single(x => x.tag == "SceneManager");
                        var sceneManager = sceneManagerGo.GetComponent<LevelMockManager>();
                        sceneManager.EnablePlayerInput();
                    }

                    SceneManager.UnloadSceneAsync("MainMenu");
                    break;
            }
        }

        private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            _stateStack.Peek().SceneLoaded(scene, loadSceneMode);
            return;
            switch (scene.name)
            {
                case "MainMenu":
                    MainMenu_SceneLoaded(scene, loadSceneMode);
                    break;
                case "LevelMock":
                    //CurrentScene = scene;
                    LevelMock_SceneLoaded(scene, loadSceneMode);
                    break;
            }
        }

        private void SceneManager_sceneUnloaded(Scene scene)
        {
            _stateStack.Peek().SceneUnloaded(scene);
            return;
            switch (scene.name)
            {
                case "MainMenu":
                    MainMenu_SceneUnloaded(scene);
                    break;
            }
        }

        private void MainMenu_SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            MenuScene = scene;

            var rootGameObjects = scene.GetRootGameObjects();
            var sceneManagerGo = rootGameObjects.Single(x => x.name == "SceneManager");
            var mainMenuManager = sceneManagerGo.GetComponent<MainMenuManager>();
            mainMenuManager.StartGameEvent += MainMenuManager_StartGameEvent;
            mainMenuManager.QuitGameEvent += MainMenuManager_QuitGameEvent;
        }


        private void MainMenu_SceneUnloaded(Scene scene)
        {
            MenuScene = default;
        }

        private void MainMenuManager_StartGameEvent(object sender, System.EventArgs e)
        {
            Debug.Log("Let's play!");

            SceneManager.UnloadSceneAsync("MainMenu");
            SceneManager.LoadSceneAsync("LevelMock", LoadSceneMode.Additive);
        }

        private void MainMenuManager_QuitGameEvent(object sender, System.EventArgs e)
        {
            Application.Quit();
        }

        private void LevelMock_SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            CurrentScene = scene;
            Debug.Log("LevelMock loaded");
        }

        private void LevelMock_SceneUnloaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            CurrentScene = default;
        }

    }
}
