using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    /// <summary>
    /// Base state for Game Manager
    /// When the GameManager enters a new state, the state is created and added to the State Stack.
    /// When the State enters the State Stack, the OnEnter method should be invoked
    /// When the State is at the top of the State Stack, it is activated, and the OnActivate method should be called
    /// When the State is in the stack, but not at the top of the stack, it is deactivated, the OnDeactivate method should be called
    /// When the State exits the State Stack, the OnExit method should be called
    /// <example>
    /// When the player starts playing, the Play state is created and added to the State Stack.
    /// It is at the top of the stack, therefore activated
    /// In order, OnEnter and OnActivate are invoked.
    /// If the player presses the Escape button, the GameManager passes to Pause state.
    /// Here, the new Pause state is created and added to the State Stack.
    /// The Play state is deactivated, no longer being at the top of the stack, and its OnDeactivated method is invoked,
    /// The Pause state is added to the State Stack, and its OnEnter and OnActivate methods are invoked, being it now at the top of the stack.
    /// If the player presses the Escape button once more, the GameManager returns to the Play state, by
    /// Removing the Pause state from the stack. This causes the Pause state to have OnDeactivate and OnExit methods invoked
    /// The Play state now returns to the top of the stack and its OnActivate method is invoked
    /// </example>
    /// </summary>
    public abstract class State
    {
        public abstract event EventHandler PauseGameEvent;
        public abstract event EventHandler ResumeGameEvent;
        public abstract event EventHandler PlayGameEvent;
        public abstract event EventHandler QuitCurrentGameEvent;
        public abstract event EventHandler QuitGameEvent;
        public abstract event EventHandler CreditsEvent;
        public abstract event EventHandler BackToMainMenuEvent;

        public IGameManager GameManager { get; private set; }
        public IUnitySceneManagerWrapper SceneManagerWrapper { get; private set; }

        public StateStateEnum StateState { get; protected set; } = StateStateEnum.NotInStack;

        public State(IGameManager gameManager, IUnitySceneManagerWrapper sceneManagerWrapper)
        {
            GameManager = gameManager;
            SceneManagerWrapper = sceneManagerWrapper;
        }
        /// <summary>
        /// Fires when the State is added to the State Stack
        /// </summary>
        public virtual void OnEnter()
        {
            Debug.Log($"State {this.GetType().Name}: OnEnter");
            StateState = StateStateEnum.InStack;

            SceneManagerWrapper.SceneLoaded += SceneLoaded;
            SceneManagerWrapper.SceneUnloaded += SceneUnloaded;
        }

        /// <summary>
        /// Fires when the State is removed from the State Stack
        /// </summary>
        public virtual void OnExit()
        {
            Debug.Log($"State {this.GetType().Name}: OnExit");
            StateState = StateStateEnum.NotInStack;

            SceneManagerWrapper.SceneLoaded -= SceneLoaded;
            SceneManagerWrapper.SceneUnloaded -= SceneUnloaded;
        }

        /// <summary>
        /// Fires when the State is Activated
        /// </summary>
        public virtual void OnActivate()
        {
            Debug.Log($"State {this.GetType().Name}: OnActivate");
            StateState = StateStateEnum.Activated;
        }

        /// <summary>
        /// Fires when the State is deactivated 
        /// </summary>
        public virtual void OnDeactivate()
        {
            Debug.Log($"State {this.GetType().Name}: OnDeactivate");
            StateState = StateStateEnum.InStack;
        }

        public virtual void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            Debug.Log($"State {this.GetType().Name}: SceneLoaded: {scene.name}");

        }

        public virtual void SceneUnloaded(Scene scene)
        {
            Debug.Log($"State {this.GetType().Name}: SceneUnloaded: {scene.name}");
        }

        public virtual void PauseResumeGame()
        {
            Debug.Log($"State {this.GetType().Name}: Pause/Resume game");
        }
    }

    public enum StateStateEnum{
        NotInStack,
        InStack,
        Activated,
    }
}
