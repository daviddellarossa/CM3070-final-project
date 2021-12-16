using System;
using FightShipArena.Assets.Scripts.Enemies;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Player
{
    public class PlayerController : MyMonoBehaviour, IPlayerController
    {
        public event Action HasDied;

        public IPlayerControllerCore Core { get; set; }

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

        protected void Core_PlayerDiesEvent()
        {
            Debug.Log("Player dies");
            HasDied?.Invoke();
            Destroy(gameObject);
        }


        void Awake()
        {
            Core = new PlayerControllerCore(this);
            Core.HasDied += Core_PlayerDiesEvent;
        }


        void Start()
        {
            if (InitSettings == null)
            {
                throw new NullReferenceException("InitSettings");
            }
            Core.Start(InitSettings);
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log($"Collision detected with {col.gameObject.name}");
            if (col.gameObject.tag == "Enemy")
            {
                var enemyController = col.gameObject.GetComponent<EnemyController>();
                var damage = enemyController.InitSettings.DamageAppliedOnCollision;
                Core.InflictDamage(damage);

            }
        }

        void FixedUpdate()
        {
            Core.Move();
        }

    }
}
