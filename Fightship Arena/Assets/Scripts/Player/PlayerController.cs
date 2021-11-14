using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Player
{
    public class PlayerController : MyMonoBehaviour
    {
        public IPlayerControllerCore Core { get; set; }

        void Awake()
        {
            Core = new PlayerControllerCore(this);
        }

        //private void Start()
        //{
        //    var playerInput = GameObject.GetComponent<PlayerInput>();
        //    playerInput.onActionTriggered += OnMove;
        //}

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
            if (context.started)
            {
                Debug.Log("OnFire started");
                //Do an action
            } else if (context.canceled)
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
            }
            else if (context.canceled)
            {
                Debug.Log("OnOpenSelectionMenu canceled");

            }

        }

        void FixedUpdate()
        {
            Core.Move();
        }
    }


}
