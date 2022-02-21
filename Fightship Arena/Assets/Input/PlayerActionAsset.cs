// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerActionAsset.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActionAsset : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActionAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActionAsset"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""44f90167-0916-4871-be60-6edbac0b6845"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""c8b67a6c-a20e-4dd8-be3b-bb55d19275e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""e445d392-53b8-4722-98e9-c281156f1111"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire Alt"",
                    ""type"": ""Button"",
                    ""id"": ""586b2380-7d8d-4f54-8ae0-b90f661c5cc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Open Selection Menu"",
                    ""type"": ""Button"",
                    ""id"": ""852733ef-7290-4c41-b1bd-81d5abd10e3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turn Left"",
                    ""type"": ""Button"",
                    ""id"": ""6e002fbe-34e4-464c-9238-a208ef54c6d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turn Right"",
                    ""type"": ""Button"",
                    ""id"": ""8356ffb9-3d32-4a6d-a4d2-e35283eb52f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turn Up"",
                    ""type"": ""Button"",
                    ""id"": ""7aa41dab-03f5-4357-9557-1514a6897443"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turn Down"",
                    ""type"": ""Button"",
                    ""id"": ""9f96ccdb-ca9d-40dc-b2d1-d22d987e3ab6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a84fcb23-6935-4731-afb2-0577b20935bd"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire Alt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""041d530e-81ed-4001-8812-e96b275e9bd4"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open Selection Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97cdd805-75bc-4ac3-9042-5eed151d7e03"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""6c9705d5-9dca-4bf4-aee4-48d267df0204"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""72bed6e2-0016-42d6-9d5b-35f1c51517af"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""088c17d4-4e02-4796-b5b5-b69e0ba68cca"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1b6fdd75-76c8-4ba9-a15b-415697168eed"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""40411201-6020-41ab-b020-50a7081d3e8d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""7b83072b-687a-4563-b999-9e0ca0057489"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Left"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""dbae14f4-7c00-49a0-8589-1d549f0dfcd9"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""e7f2986f-7d0b-42ac-b661-224080dffd2e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""07544bb2-807d-4a78-897c-f5b51568a11f"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""b0bbee40-4322-48aa-9040-0c8a50fe50dc"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""0926fdd9-6dac-4247-bd2f-e730cc63ca2d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""b1fc86c0-7b3c-4e0d-8b2b-c04955750b51"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Up"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""5ded0678-824d-47fa-94e8-43c022085c9f"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""82481071-b819-4926-b8e3-c3a62134c79d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""3c97f6d3-0c96-4cb2-ac8d-1613b62a1d9d"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Down"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0c44abca-af04-4b9e-ac8d-84ca38e1c0ca"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""708c0361-482a-4a53-be9f-6dc7bb4ab9ef"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""GameManager"",
            ""id"": ""fb0ae8bf-2de8-4b52-ba27-b123c94c1587"",
            ""actions"": [
                {
                    ""name"": ""PauseResume"",
                    ""type"": ""Button"",
                    ""id"": ""d2ed8da1-6c65-4bfc-b56a-2b866f64a6b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6590e0c5-b9c3-4e05-90fa-d3895c8fc6aa"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseResume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b064888c-d3e3-401c-bbe5-046d05771177"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseResume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Test"",
            ""id"": ""4ed0035d-3ec2-4b82-8280-c8a804875ae1"",
            ""actions"": [
                {
                    ""name"": ""SpawnPawn"",
                    ""type"": ""Button"",
                    ""id"": ""6968d789-3b4d-42d4-b790-912e82f372f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""df0123cc-30ea-4619-8fae-f491439b9497"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpawnPawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_FireAlt = m_Player.FindAction("Fire Alt", throwIfNotFound: true);
        m_Player_OpenSelectionMenu = m_Player.FindAction("Open Selection Menu", throwIfNotFound: true);
        m_Player_TurnLeft = m_Player.FindAction("Turn Left", throwIfNotFound: true);
        m_Player_TurnRight = m_Player.FindAction("Turn Right", throwIfNotFound: true);
        m_Player_TurnUp = m_Player.FindAction("Turn Up", throwIfNotFound: true);
        m_Player_TurnDown = m_Player.FindAction("Turn Down", throwIfNotFound: true);
        // GameManager
        m_GameManager = asset.FindActionMap("GameManager", throwIfNotFound: true);
        m_GameManager_PauseResume = m_GameManager.FindAction("PauseResume", throwIfNotFound: true);
        // Test
        m_Test = asset.FindActionMap("Test", throwIfNotFound: true);
        m_Test_SpawnPawn = m_Test.FindAction("SpawnPawn", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_FireAlt;
    private readonly InputAction m_Player_OpenSelectionMenu;
    private readonly InputAction m_Player_TurnLeft;
    private readonly InputAction m_Player_TurnRight;
    private readonly InputAction m_Player_TurnUp;
    private readonly InputAction m_Player_TurnDown;
    public struct PlayerActions
    {
        private @PlayerActionAsset m_Wrapper;
        public PlayerActions(@PlayerActionAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @FireAlt => m_Wrapper.m_Player_FireAlt;
        public InputAction @OpenSelectionMenu => m_Wrapper.m_Player_OpenSelectionMenu;
        public InputAction @TurnLeft => m_Wrapper.m_Player_TurnLeft;
        public InputAction @TurnRight => m_Wrapper.m_Player_TurnRight;
        public InputAction @TurnUp => m_Wrapper.m_Player_TurnUp;
        public InputAction @TurnDown => m_Wrapper.m_Player_TurnDown;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @FireAlt.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireAlt;
                @FireAlt.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireAlt;
                @FireAlt.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireAlt;
                @OpenSelectionMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenSelectionMenu;
                @OpenSelectionMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenSelectionMenu;
                @OpenSelectionMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenSelectionMenu;
                @TurnLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnLeft;
                @TurnLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnLeft;
                @TurnLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnLeft;
                @TurnRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnRight;
                @TurnRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnRight;
                @TurnRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnRight;
                @TurnUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnUp;
                @TurnUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnUp;
                @TurnUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnUp;
                @TurnDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnDown;
                @TurnDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnDown;
                @TurnDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnDown;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @FireAlt.started += instance.OnFireAlt;
                @FireAlt.performed += instance.OnFireAlt;
                @FireAlt.canceled += instance.OnFireAlt;
                @OpenSelectionMenu.started += instance.OnOpenSelectionMenu;
                @OpenSelectionMenu.performed += instance.OnOpenSelectionMenu;
                @OpenSelectionMenu.canceled += instance.OnOpenSelectionMenu;
                @TurnLeft.started += instance.OnTurnLeft;
                @TurnLeft.performed += instance.OnTurnLeft;
                @TurnLeft.canceled += instance.OnTurnLeft;
                @TurnRight.started += instance.OnTurnRight;
                @TurnRight.performed += instance.OnTurnRight;
                @TurnRight.canceled += instance.OnTurnRight;
                @TurnUp.started += instance.OnTurnUp;
                @TurnUp.performed += instance.OnTurnUp;
                @TurnUp.canceled += instance.OnTurnUp;
                @TurnDown.started += instance.OnTurnDown;
                @TurnDown.performed += instance.OnTurnDown;
                @TurnDown.canceled += instance.OnTurnDown;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // GameManager
    private readonly InputActionMap m_GameManager;
    private IGameManagerActions m_GameManagerActionsCallbackInterface;
    private readonly InputAction m_GameManager_PauseResume;
    public struct GameManagerActions
    {
        private @PlayerActionAsset m_Wrapper;
        public GameManagerActions(@PlayerActionAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseResume => m_Wrapper.m_GameManager_PauseResume;
        public InputActionMap Get() { return m_Wrapper.m_GameManager; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameManagerActions set) { return set.Get(); }
        public void SetCallbacks(IGameManagerActions instance)
        {
            if (m_Wrapper.m_GameManagerActionsCallbackInterface != null)
            {
                @PauseResume.started -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnPauseResume;
                @PauseResume.performed -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnPauseResume;
                @PauseResume.canceled -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnPauseResume;
            }
            m_Wrapper.m_GameManagerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseResume.started += instance.OnPauseResume;
                @PauseResume.performed += instance.OnPauseResume;
                @PauseResume.canceled += instance.OnPauseResume;
            }
        }
    }
    public GameManagerActions @GameManager => new GameManagerActions(this);

    // Test
    private readonly InputActionMap m_Test;
    private ITestActions m_TestActionsCallbackInterface;
    private readonly InputAction m_Test_SpawnPawn;
    public struct TestActions
    {
        private @PlayerActionAsset m_Wrapper;
        public TestActions(@PlayerActionAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @SpawnPawn => m_Wrapper.m_Test_SpawnPawn;
        public InputActionMap Get() { return m_Wrapper.m_Test; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestActions set) { return set.Get(); }
        public void SetCallbacks(ITestActions instance)
        {
            if (m_Wrapper.m_TestActionsCallbackInterface != null)
            {
                @SpawnPawn.started -= m_Wrapper.m_TestActionsCallbackInterface.OnSpawnPawn;
                @SpawnPawn.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnSpawnPawn;
                @SpawnPawn.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnSpawnPawn;
            }
            m_Wrapper.m_TestActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SpawnPawn.started += instance.OnSpawnPawn;
                @SpawnPawn.performed += instance.OnSpawnPawn;
                @SpawnPawn.canceled += instance.OnSpawnPawn;
            }
        }
    }
    public TestActions @Test => new TestActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnFireAlt(InputAction.CallbackContext context);
        void OnOpenSelectionMenu(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnTurnUp(InputAction.CallbackContext context);
        void OnTurnDown(InputAction.CallbackContext context);
    }
    public interface IGameManagerActions
    {
        void OnPauseResume(InputAction.CallbackContext context);
    }
    public interface ITestActions
    {
        void OnSpawnPawn(InputAction.CallbackContext context);
    }
}
