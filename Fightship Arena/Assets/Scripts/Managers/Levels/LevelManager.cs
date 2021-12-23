using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.SceneManagement;
using FightShipArena.Assets.Scripts.Managers.ScoreManagement;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.Levels
{
    public class LevelManager : SceneManager
    {
        public IPlayerControllerCore PlayerControllerCore { get; set; }
        public IScoreManager ScoreManager { get; set; }

        public virtual void Move(InputAction.CallbackContext context){}

        public virtual void DisablePlayerInput(){}

        public virtual void EnablePlayerInput(){}
    }
}
