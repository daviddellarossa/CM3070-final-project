using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.EnemyManagement;
using FightShipArena.Assets.Scripts.Managers.OrchestrationManagement;
using FightShipArena.Assets.Scripts.Managers.ScoreManagement;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.Levels
{
    //[RequireComponent(typeof(EnemyManagement.EnemyManager))]
    [RequireComponent(typeof(OrchestrationManagement.OrchestrationManager))]
    public class LevelMockManager : LevelManager, ILevelMockManager
    {
        public ILevelMockManagerCore Core { get; protected set; }
        private PlayerInput _playerInput;

        void Awake()
        {
            ScoreManager = GameObject.GetComponent<IScoreManager>();
            //EnemyManager = GameObject.GetComponent<IEnemyManager>();
            OrchestrationManager = GameObject.GetComponent<IOrchestrationManager>();
            OrchestrationManager.SendScore += EnemyManagerSendScore;
            OrchestrationManager.OrchestrationComplete += OrchestrationManager_OrchestrationComplete;

            Core = new LevelMockManagerCore(this);

            OnAwake();
        }

        private void OrchestrationManager_OrchestrationComplete()
        {
            Debug.Log("Orchestration complete");
        }

        private void EnemyManagerSendScore(int value)
        {
            ScoreManager.AddToScore(value);
        }

        void Start()
        {
            OnStart();
        }


        public void OnStart()
        {
            var player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                throw new NullReferenceException("Player object not found");
            }

            this.PlayerControllerCore = player.GetComponent<IPlayerController>().Core;
            this.PlayerControllerCore.ScoreMultiplierCollected += PlayerControllerCore_ScoreMultiplierCollected;

            Core.OnStart();
        }

        private void PlayerControllerCore_ScoreMultiplierCollected(int value)
        {
            ScoreManager.AddMultiplier(value);
        }

        public void OnAwake()
        {
            Core.OnAwake();
        }

        public override void Move(InputAction.CallbackContext context)
        {
            Core.Move(context);
        }

        public override void DisablePlayerInput()
        {
            Core.DisablePlayerInput();
        }

        public override void EnablePlayerInput()
        {
            Core.EnablePlayerInput();
        }
    }

}
