using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Infantry.StateMachine
{
    public class IdleState : InfantryState
    {
        public override event Action<IInfantryState> ChangeState;

        public IdleState(InfantryControllerCore parent, StateFactory factory)
        {
            Parent = parent;
            Factory = factory;
        }
    }
}
