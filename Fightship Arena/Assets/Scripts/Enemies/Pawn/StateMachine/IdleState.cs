using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Pawn.StateMachine
{
    public class IdleState : PawnState
    {
        public override event Action<IPawnState> ChangeState;

        public IdleState(PawnControllerCore parent, StateFactory factory)
        {
            Parent = parent;
            Factory = factory;
        }
    }
}
