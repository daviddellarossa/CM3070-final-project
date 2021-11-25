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
    public class LevelMockManager : LevelManager
    {
        private PlayerInput _playerInput;
        void Start()
        {
            Debug.Log($"Level started");

            _playerInput = GetComponent<PlayerInput>();
        }


        public override void Move(InputAction.CallbackContext context)
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

        public override void DisablePlayerInput()
        {
            _playerInput.enabled = false;
        }

        public override void EnablePlayerInput()
        {
            _playerInput.enabled = true;
        }
    }
}
