using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private readonly StateStack _stateStack = new StateStack();

        #region MonoBehaviour methods

        void Awake()
        {
            Core = new GameManagerCore(this);

            _stateStack.PoppingStateEvent += StateStack_PoppingStateEvent;
            _stateStack.PushingStateEvent += StateStack_PushingStateEvent;
        }

        void Start()
        {
            State_PushStateRequestEvent(new Init(this));
        }

        #endregion

        #region Event Handlers for StateStack events

        private void StateStack_PushingStateEvent(object sender, State state)
        {
            state.PauseGameEvent += State_PauseGameEvent;
            state.PlayGameEvent += State_PlayGameEvent;
            state.ResumeGameEvent += State_ResumeGameEvent;
            state.QuitCurrentGameEvent += State_QuitCurrentGameEvent;
            state.QuitGameEvent += State_QuitGameEvent;
        }

        private void StateStack_PoppingStateEvent(object sender, State state)
        {
            state.PauseGameEvent -= State_PauseGameEvent;
            state.PlayGameEvent -= State_PlayGameEvent;
            state.ResumeGameEvent -= State_ResumeGameEvent;
            state.QuitCurrentGameEvent -= State_QuitCurrentGameEvent;
            state.QuitGameEvent -= State_QuitGameEvent;
        }

        #endregion

        #region Handler methods for StateStack

        private void State_ReplaceStateRequestEvent(State state)
        {
            State_PopStateRequestEvent();

            State_PushStateRequestEvent(state);
        }

        private void State_PushStateRequestEvent(State state)
        {
            _stateStack.Push(state);
        }

        private void State_PopStateRequestEvent()
        {
            var state = _stateStack.Pop();
        }

        #endregion

        #region Event Handlers for State events

        private void State_PauseGameEvent(object sender, EventArgs e)
        {
            State_PushStateRequestEvent(new Pause(this));
        }

        private void State_ResumeGameEvent(object sender, EventArgs e)
        {
            State_PopStateRequestEvent();
        }

        private void State_PlayGameEvent(object sender, EventArgs e)
        {
            State_ReplaceStateRequestEvent(new Play(this));
        }

        private void State_QuitCurrentGameEvent(object sender, EventArgs e)
        {
            _stateStack.Clear();
            State_PushStateRequestEvent(new Init(this));
        }

        private void State_QuitGameEvent(object sender, EventArgs e)
        {
            State_PushStateRequestEvent(new Quit(this));
        }
        #endregion

        #region Input Event Handlers

        /// <summary>
        /// Event Handler for PauseResume actions
        /// Invokes PauseResume on the current state
        /// </summary>
        /// <param name="context"></param>
        public void PauseResumeGame(InputAction.CallbackContext context)
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
