using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.EnemyManagement;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.Levels
{
    public class Level_01ManagerCore : ILevelManagerCore
    {
        public readonly ILevelManager Parent;
        public IPlayerControllerCore PlayerControllerCore { get; set; }

        public bool SpawnEnemiesEnabled = true;

        protected PlayerInput _playerInput;

        public Level_01ManagerCore(ILevelManager parent)
        {
            Parent = parent;

        }

        public void OnStart()
        {
            this.PlayerControllerCore = Parent.PlayerControllerCore;
            this.PlayerControllerCore.HealthManager.HasDied += PlayerHasDied;
            Debug.Log($"Level started");

            this.PlayerControllerCore.HealthManager.Heal();

            if (SpawnEnemiesEnabled)
            {
                this.Parent.OrchestrationManager.Run();
            }
        }

        private void PlayerHasDied()
        {
            this.Parent.OrchestrationManager.Stop();
            //Change LevelManager state to GameOver
        }

        public void OnAwake() 
        {
            _playerInput = Parent.GameObject.GetComponent<PlayerInput>();
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
