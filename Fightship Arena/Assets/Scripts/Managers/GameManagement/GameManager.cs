using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement
{
    public class GameManager : MyMonoBehaviour, IGameManager
    {
        public IGameManager Core { get; protected set; }

        [SerializeField]
        private SoundManager _SoundManager;
        public ISoundManager SoundManager => _SoundManager;

        #region MonoBehaviour methods

        void Awake()
        {
            OnAwake();
        }

        void Start()
        {
            OnStart();
        }

        #endregion


        #region Input Event Handlers

        /// <summary>
        /// Event Handler for PauseResume actions
        /// Invokes PauseResume on the current state
        /// </summary>
        /// <param name="context"></param>
        public void PauseResumeGame(InputAction.CallbackContext context)
        {
            OnPauseResumeGame(context);
        }

        #endregion

        public void OnAwake()
        {
            Core = new GameManagerCore(this);
            Core.OnAwake();
        }

        public void OnStart()
        {
            Core.OnStart();
        }

        public void OnPauseResumeGame(InputAction.CallbackContext context)
        {
            Core.OnPauseResumeGame(context);
        }
    }
}
