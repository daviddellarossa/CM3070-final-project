using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.Levels.StateMachine;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.Levels
{
    public class Level_01ManagerCore : ILevelManagerCore
    {
        public IPlayerControllerCore PlayerControllerCore { get; set; }

        public State CurrentState { get; private set; }
        public ILevelManager LevelManager { get; set; }

        public bool SpawnEnemiesEnabled = true;

        protected PlayerInput _playerInput;

        private StateConfiguration _stateConfiguration;

        public Level_01ManagerCore(ILevelManager levelManager)
        {
            LevelManager = levelManager;

        }

        public void OnStart()
        {
            this.PlayerControllerCore = LevelManager.PlayerControllerCore;
            this.PlayerControllerCore.HealthManager.HasDied += PlayerHasDied;
            this.PlayerControllerCore.ScoreMultiplierCollected += PlayerControllerCore_ScoreMultiplierCollected;

            Debug.Log($"Level started");

            this.PlayerControllerCore.HealthManager.Heal();

            _stateConfiguration = new StateConfiguration(
                levelManagerCore: this,
                orchestrationManager: this.LevelManager.OrchestrationManager,
                hudManager: this.LevelManager.HudManager,
                spawnEnemiesEnabled: true
            );

            ChangeStateRequestEventHandler(this, new WaitForStart(_stateConfiguration));
        }

        private void PlayerControllerCore_ScoreMultiplierCollected(int value)
        {
            LevelManager.ScoreManager.AddToMultiplier(value);
        }

        /// <summary>
        /// Handler for a request to change current state.
        /// </summary>
        /// <param name="sender">The sender of the request.</param>
        /// <param name="e">The new state.</param>
        protected void ChangeStateRequestEventHandler(object sender, State e)
        {
            //Debug.Log($"Changing state from {sender} to {e}");
            if (CurrentState != null)
            {
                CurrentState.ChangeStateRequestEvent -= ChangeStateRequestEventHandler;
                CurrentState.OnExit();
            }
            CurrentState = e;
            CurrentState.ChangeStateRequestEvent += ChangeStateRequestEventHandler;
            CurrentState.OnEnter();
        }

        private void PlayerHasDied()
        {
            ChangeStateRequestEventHandler(this, new GameOver(_stateConfiguration));
        }

        public void OnAwake() 
        {
            LevelManager.OrchestrationManager.SendScore += OrchestrationManager_SendScore;
            LevelManager.OrchestrationManager.OrchestrationComplete += OrchestrationManager_OrchestrationComplete;

            _playerInput = LevelManager.GameObject.GetComponent<PlayerInput>();
        }

        private void OrchestrationManager_OrchestrationComplete()
        {
            Debug.Log("Orchestration complete");
            //LevelManager.ScoreManager.AddToHighScore();
            ChangeStateRequestEventHandler(this, new Win(_stateConfiguration));

        }

        private void OrchestrationManager_SendScore(int value)
        {
            LevelManager.ScoreManager.AddToScore(value);
        }


        public void Move(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {

                case InputActionPhase.Started:
                    Debug.Log($"{context.action} Started");
                    break;
                case InputActionPhase.Performed:
                    Debug.Log($"{context.action} Performed");
                    break;
                case InputActionPhase.Canceled:
                    Debug.Log($"{context.action} Cancelled");
                    break;
            }
        }

        public void DisablePlayerInput()
        {
            _playerInput.enabled = false;
        }

        public void EnablePlayerInput()
        {
            _playerInput.enabled = true;
        }
    }
}
