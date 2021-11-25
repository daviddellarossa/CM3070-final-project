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
    public class GameManager : MyMonoBehaviour
    {
        public IGameManagerCore Core { get; private set; }

        #region MonoBehaviour methods

        void Awake()
        {
            Core = new GameManagerCore(this);
            Core.OnAwake();
        }

        void Start()
        {
            Core.OnStart();
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
            Core.OnPauseResumeGame(context);
        }

        #endregion

    }
}
