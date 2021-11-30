using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine;
using FightShipArena.Assets.Scripts.Managers.Levels;
using FightShipArena.Assets.Scripts.Managers.Menus;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement
{
    public class GameManager : MyMonoBehaviour, IGameManager
    {
        public IGameManager Core { get; protected set; }

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
