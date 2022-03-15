using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.Levels;
using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class Play : State
    {
        public override event EventHandler PauseGameEvent;
        public override event EventHandler ResumeGameEvent;
        public override event EventHandler PlayGameEvent;
        public override event EventHandler QuitCurrentGameEvent;
        public override event EventHandler QuitGameEvent;
        public override event EventHandler CreditsEvent;
        public override event EventHandler BackToMainMenuEvent;
        public override event EventHandler HelpEvent;

        public readonly string _sceneName = "Level_01";
        protected ILevelManager _levelManager;

        public Play(
            IGameManager gameManager,
            IUnitySceneManagerWrapper sceneManagerWrapper
        ) : base(gameManager, sceneManagerWrapper) { }

        public override void OnEnter()
        {
            base.OnEnter();

            SceneManagerWrapper.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
            GameManager.SoundManager.PlayMusic(GameManager.SoundManager.GameMusic);
        }

        public override void OnExit()
        {
            base.OnExit();

            SceneManagerWrapper.UnloadSceneAsync(_sceneName);
        }

        public override void OnActivate()
        {
            base.OnActivate();

            GameManager.SoundManager.PlayMusic(GameManager.SoundManager.GameMusic);

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
            _levelManager.PlaySoundEvent += LevelManager_PlaySoundEvent;
            _levelManager.ReturnToMainEvent += LevelManager_ReturnToMain;
        }

        private void LevelManager_ReturnToMain()
        {
            QuitCurrentGameEvent?.Invoke(this, null);
        }

        private void LevelManager_PlaySoundEvent(object sender, Sound e)
        {
            GameManager.SoundManager.PlaySound(e);
        }

        //This method is non-testable because it accesses Scene's methods and GameObject's methods, which are not mockable.
        protected virtual ILevelManager GetSceneManagerFromScene(Scene scene)
        {
            if (scene.name != _sceneName)
                return null;

            var rootGameObjects = scene.GetRootGameObjects();
            var sceneManagerGo = rootGameObjects.Single(x => x.name == "SceneManager");
            var levelManager = sceneManagerGo.GetComponent<Level_01Manager>();

            return levelManager;
        }


        public override void PauseResumeGame()
        {
            base.PauseResumeGame();

            PauseGameEvent?.Invoke(this, new EventArgs());
        }

    }
}
