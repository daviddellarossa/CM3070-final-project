using System;
using FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine;
using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement
{
    public class GameManagerCore : IGameManager
    {
        public readonly IMyMonoBehaviour Parent;
        private IUnitySceneManagerWrapper _sceneManagerWrapper;

        protected StateStack _stateStack = new StateStack();

        public ISoundManager SoundManager { get; protected set; }

        public GameManagerCore(IMyMonoBehaviour parent)
        {
            Parent = parent;
            SoundManager = (Parent as IGameManager).SoundManager;
            _sceneManagerWrapper = UnitySceneManagerWrapper.Instance;
        }

        #region MonoBehaviour methods

        public void OnAwake()
        {
            _stateStack.PoppingStateEvent += StateStack_PoppingStateEvent;
            _stateStack.PushingStateEvent += StateStack_PushingStateEvent;
        }

        public void OnStart()
        {
            PushState(new Init(this, _sceneManagerWrapper));
        }

        #endregion

        #region Event Handlers for StateStack events

        protected virtual void StateStack_PushingStateEvent(object sender, State state)
        {
            state.PauseGameEvent += State_PauseGameEvent;
            state.PlayGameEvent += State_PlayGameEvent;
            state.ResumeGameEvent += State_ResumeGameEvent;
            state.QuitCurrentGameEvent += State_QuitCurrentGameEvent;
            state.QuitGameEvent += State_QuitGameEvent;
            state.CreditsEvent += State_CreditsEvent;
            state.HelpEvent += State_HelpEvent;
            state.BackToMainMenuEvent += State_BackToMainMenuEvent;
        }

        protected virtual void StateStack_PoppingStateEvent(object sender, State state)
        {
            state.PauseGameEvent -= State_PauseGameEvent;
            state.PlayGameEvent -= State_PlayGameEvent;
            state.ResumeGameEvent -= State_ResumeGameEvent;
            state.QuitCurrentGameEvent -= State_QuitCurrentGameEvent;
            state.QuitGameEvent -= State_QuitGameEvent;
            state.CreditsEvent -= State_CreditsEvent;
            state.HelpEvent -= State_HelpEvent;
            state.BackToMainMenuEvent -= State_BackToMainMenuEvent;
        }

        #endregion

        #region Handler methods for StateStack

        protected virtual void ReplaceState(State state)
        {
            PopState();

            PushState(state);
        }

        protected virtual void PushState(State state)
        {
            _stateStack.Push(state);
        }

        protected virtual void PopState()
        {
            var state = _stateStack.Pop();
        }

        #endregion

        #region Event Handlers for State events

        protected virtual void State_PauseGameEvent(object sender, EventArgs e)
        {
            PushState(new Pause(this, _sceneManagerWrapper));
        }
        protected virtual void State_ResumeGameEvent(object sender, EventArgs e)
        {
            PopState();
        }

        private void State_CreditsEvent(object sender, EventArgs e)
        {
            ReplaceState(new Credits(this, _sceneManagerWrapper));
        }
        private void State_HelpEvent(object sender, EventArgs e)
        {
            ReplaceState(new Help(this, _sceneManagerWrapper));
        }

        protected virtual void State_PlayGameEvent(object sender, EventArgs e)
        {
            ReplaceState(new Play(this, _sceneManagerWrapper));
        }
        protected virtual void State_QuitCurrentGameEvent(object sender, EventArgs e)
        {
            _stateStack.Clear();
            PushState(new Init(this, _sceneManagerWrapper));
        }
        protected virtual void State_QuitGameEvent(object sender, EventArgs e)
        {
            PushState(new Quit(this, _sceneManagerWrapper));

            Application.Quit();
        }

        protected virtual void State_BackToMainMenuEvent(object sender, EventArgs e)
        {
            ReplaceState(new Init(this, _sceneManagerWrapper));
        }


        #endregion

        #region Input Event Handlers

        /// <summary>
        /// Event Handler for PauseResume actions
        /// Invokes PauseResume on the current state
        /// <remarks>This method is not testable, as the input parameter cannot be mocked</remarks>
        /// </summary>
        /// <param name="context"></param>
        public void OnPauseResumeGame(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    Debug.Log($"{context.action} Performed");

                    _stateStack.Peek()?.PauseResumeGame();
                    break;
            }
        }

        #endregion

    }
}
