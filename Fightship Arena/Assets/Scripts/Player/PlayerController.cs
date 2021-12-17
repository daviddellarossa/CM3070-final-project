using System;
using FightShipArena.Assets.Scripts.Enemies;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Player
{
    public class PlayerController : MyMonoBehaviour
    {

        public IPlayerControllerCore Core { get; set; }
        public IHealthManager HealthManager { get; protected set; }

        [SerializeField]
        private PlayerSettings InitSettings;


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
                Core.Movement = new Vector3(inputVector.x, inputVector.y);
                Debug.Log($"Moving {Core.Movement}");

            }
            else if (context.canceled)
            {
                Debug.Log("Not moving");
                Core.Movement = new Vector3(inputVector.x, inputVector.y);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// For testing <see cref="https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Testing.html"/>
        /// <param name="context"></param>
        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("OnFire started");
                //Do an action
                Core.Fire();
            }
            else if (context.canceled)
            {
                Debug.Log("OnFire canceled");

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

        void Awake()
        {
            HealthManager = new HealthManager(InitSettings.InitHealth, InitSettings.InitHealth, false);
            HealthManager.HasDied += HealthManager_HasDied;
            HealthManager.HealthLevelChanged += HealthManager_HealthLevelChanged; 

            Core = new PlayerControllerCore(this, HealthManager, InitSettings);
        }


        void Start()
        {
            if (InitSettings == null)
            {
                throw new NullReferenceException("InitSettings");
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log($"Collision detected with {col.gameObject.name}");
            if (col.gameObject.tag == "Enemy")
            {
                var enemyController = col.gameObject.GetComponent<EnemyController>();
                Core.HandleCollisionWithEnemy(enemyController.Core);
            }
        }

        void FixedUpdate()
        {
            Core.Move();
        }
        private void HealthManager_HealthLevelChanged(int obj)
        {
        }

        private void HealthManager_HasDied()
        {
            Debug.Log($"Destroying object {this.gameObject.name}");
            Destroy(this.gameObject);
        }

    }
}
