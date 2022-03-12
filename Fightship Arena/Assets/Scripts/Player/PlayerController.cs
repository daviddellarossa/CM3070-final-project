using System;
using System.Collections.Generic;
using System.Linq;
using FightShipArena.Assets.Scripts.Enemies;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Managers.Levels;
using FightShipArena.Assets.Scripts.Weapons;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Player
{
    public class PlayerController : MyMonoBehaviour, IPlayerController
    {
        public UnityEvent<int, int> PlayerHealthLevelChanged;
        public UnityEvent PlayerHasDied;

        protected PlayerSoundManager _SoundManager;

        public IPlayerControllerCore Core { get; set; }
        public IHealthManager HealthManager { get; protected set; }
        public PlayerSettings InitSettings => initSettings;

        public WeaponBase[] Weapons { get; protected set; }

        [SerializeField]
        private PlayerSettings initSettings;

        /// <summary>
        ///  
        /// </summary>
        /// For testing <see cref="https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Testing.html"/>
        /// <param name="context"></param>
        public void OnMove(InputAction.CallbackContext context)
        {
            var inputVector = context.ReadValue<Vector2>();

            if (context.performed)
            {
                Core.SetPlayerInput(inputVector);
                Debug.Log($"Moving {Core.PlayerInput}");

            }
            else if (context.canceled)
            {
                Debug.Log("Not moving");
                Core.SetPlayerInput(inputVector);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// For testing <see cref="https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Testing.html"/>
        /// <param name="context"></param>
        public void OnFire(InputAction.CallbackContext context)
        {
            
            if (context.started)
            {
                Debug.Log("OnFire started");
                Core.StartFiring();
            }
            else if (context.canceled)
            {
                Debug.Log("OnFire canceled");
                Core.StopFiring();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// For testing <see cref="https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Testing.html"/>
        /// <param name="context"></param>
        public void OnFireAlt(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Debug.Log("OnFireAlt started");
                //Do an action
                Core.FireAlt();
            }
            else if (context.canceled)
            {
                Debug.Log("OnFireAlt canceled");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// For testing <see cref="https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Testing.html"/>
        /// <param name="context"></param>
        public void OnOpenSelectionMenu(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Debug.Log("OnOpenSelectionMenu started");
                //Do an action
                Core.OpenSelectionMenu();
            }
            else if (context.canceled)
            {
                Debug.Log("OnOpenSelectionMenu canceled");
            }
        }

        public void OnTurnLeft(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Core.TurnLeft();
                Debug.Log($"Turning {Core.PlayerInput}");
            }
            else if (context.canceled)
            {
            }
        }

        public void OnTurnRight(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Core.TurnRight();
                Debug.Log($"Turning {Core.PlayerInput}");
            }
            else if (context.canceled)
            {
            }
        }

        public void OnTurnUp(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Core.TurnUp();
                Debug.Log($"Turning {Core.PlayerInput}");
            }
            else if (context.canceled)
            {
            }
        }

        public void OnTurnDown(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Core.TurnDown();
                Debug.Log($"Turning {Core.PlayerInput}");
            }
            else if (context.canceled)
            {
            }
        }

        void Awake()
        {
            HealthManager = new HealthManager(initSettings.InitHealth, initSettings.InitHealth, false);
            HealthManager.HasDied += HealthManager_HasDied;
            HealthManager.HealthLevelChanged += HealthManager_HealthLevelChanged;

            CheckWeaponsConfiguration();

            Core = new PlayerControllerCore(this);
        }

        private void CheckWeaponsConfiguration()
        {
            Weapons = this.GameObject.GetComponentsInChildren<WeaponBase>();
            foreach (var weapon in Weapons)
            {
                //Check if there is a new settings for the current weapon. If there is, assign.
                var weaponSettings =
                    initSettings.WeaponSettings.SingleOrDefault(x => x.WeaponType == weapon.WeaponType);
                if (weaponSettings != null)
                {
                    weapon.InitSettings = weaponSettings;
                }

                //If the current weapon has no configuration, throw.
                if (weapon.InitSettings == null)
                {
                    throw new Exception($"No settings for weapon {weapon.WeaponType}");
                }
            }
        }

        void Start()
        {
            if (initSettings == null)
            {
                throw new NullReferenceException("InitSettings");
            }

            var sceneManagerGO = GameObject.FindGameObjectWithTag("SceneManager");
            var sceneManager = sceneManagerGO?.GetComponent<LevelManager>();

            if (sceneManager == null)
            {
                Debug.LogError("SceneManager not found");
            }

            _SoundManager = gameObject.GetComponent<PlayerSoundManager>();

            if (_SoundManager == null)
            {
                Debug.LogError("SoundManager not found");
            }

            _SoundManager.SceneManager = sceneManager;


        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log($"Collision detected with {col.gameObject.name}");
            if (col.gameObject.tag == "Enemy")
            {
                var enemyController = col.gameObject.GetComponent<EnemyController>();
                Core.HandleCollisionWithEnemy(enemyController.Core);
            }
            else if(col.gameObject.tag == "EnemyBullet")
            {
                _SoundManager.PlayHitSound();
            }
        }

        void FixedUpdate()
        {
            Core.Move();
        }
        private void HealthManager_HealthLevelChanged(int value, int maxValue)
        {
            PlayerHealthLevelChanged?.Invoke(value, maxValue);
        }

        private void HealthManager_HasDied()
        {
            PlayerHasDied?.Invoke();

            _SoundManager.PlayExplodeSound();

            Debug.Log($"Destroying object {this.gameObject.name}");
            Destroy(this.gameObject);
        }

    }
}
