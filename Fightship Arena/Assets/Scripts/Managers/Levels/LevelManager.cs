using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.EnemyManagement;
using FightShipArena.Assets.Scripts.Managers.HudManagement;
using FightShipArena.Assets.Scripts.Managers.OrchestrationManagement;
using FightShipArena.Assets.Scripts.Managers.SceneManagement;
using FightShipArena.Assets.Scripts.Managers.ScoreManagement;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.Levels
{
    public class LevelManager : SceneManager, ILevelManager
    {
        public IPlayerControllerCore PlayerControllerCore { get; set; }
        public IScoreManager ScoreManager { get; set; }
        public IOrchestrationManager OrchestrationManager { get; set; }
        public IHudManager HudManager { get; set; }

        public virtual void Move(InputAction.CallbackContext context){}

        public virtual void DisablePlayerInput(){}

        public virtual void EnablePlayerInput(){}

        public virtual void OnStart() 
        {
            var player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                throw new NullReferenceException("Player object not found");
            }

            this.PlayerControllerCore = player.GetComponent<IPlayerController>().Core;

            this.HudManager = GetComponent<IHudManager>();
            if(HudManager == null)
            {
                Debug.LogError("HudManager not found in LevelManager OnStart");
            }
        }

        public virtual void OnAwake() { }
    }
}
