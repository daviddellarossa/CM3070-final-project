using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Enemies.Pawn.StateMachine
{
    public class StateFactory
    {
        public PawnControllerCore Parent { get; set; }
        public IPawnState AttackState { get; protected set; }
        public IPawnState SeekState { get; protected set; }
        public IPawnState IdleState { get; protected set; }

        public StateFactory(PawnControllerCore parent)
        {
            this.Parent = parent;
            AttackState = new AttackState(this.Parent, this);
            SeekState = new SeekState(this.Parent, this);
            IdleState = new IdleState(this.Parent, this);

        }
    }

}
