using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.Levels
{
    public class LevelMockManager : LevelManager, ILevelMockManager
    {
        public ILevelMockManager Core { get; protected set; }

        private PlayerInput _playerInput;

        void Awake()
        {
            OnAwake();
        }

        void Start()
        {
            OnStart();
        }


        public void OnStart()
        {
            Core.OnStart();
        }

        public void OnAwake()
        {
            Core = new LevelMockManagerCore(this);
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
