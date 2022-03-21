using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.EnemyManagement;
using FightShipArena.Assets.Scripts.Managers.OrchestrationManagement;
using FightShipArena.Assets.Scripts.Managers.OrchestrationManagement2;
using FightShipArena.Assets.Scripts.Managers.ScoreManagement;
using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FightShipArena.Assets.Scripts.Managers.Levels
{
    public class Level_01Manager : LevelManager
    {
        public ILevelManagerCore Core { get; protected set; }
        private PlayerInput _playerInput;

        public override event EventHandler<Sound> PlaySoundEvent;
        public override event Action ReturnToMainEvent;

        void Awake()
        {
            ScoreManager = GameObject.GetComponent<IScoreManager>();
            OrchestrationManager = GameObject.GetComponent<IOrchestrationManager>();

            Core = new Level_01ManagerCore(this);

            OnAwake();
        }

        void Start()
        {
            OnStart();
        }

        public void OnStart()
        {
            base.OnStart();
            Core.OnStart();
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
        public override void PlaySound(Sound sound)
        {
            PlaySoundEvent?.Invoke(this, sound);
        }
        public override void ReturnToMain()
        {
            ReturnToMainEvent?.Invoke();
        }
    }
}
