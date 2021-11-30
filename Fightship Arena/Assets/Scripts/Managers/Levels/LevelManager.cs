using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Managers.SceneManagement;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.Levels
{
    public class LevelManager : SceneManager
    {
        public virtual void Move(InputAction.CallbackContext context){}

        public virtual void DisablePlayerInput(){}

        public virtual void EnablePlayerInput(){}
    }
}
