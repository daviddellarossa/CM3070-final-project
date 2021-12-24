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
                    ""processors"": ""InputScaler(ScaleFactor=100)"",
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
    public struct PlayerActions
    {
        private @PlayerActionAsset m_Wrapper;
        public PlayerActions(@PlayerActionAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @FireAlt => m_Wrapper.m_Player_FireAlt;
        public InputAction @OpenSelectionMenu => m_Wrapper.m_Player_OpenSelectionMenu;
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
