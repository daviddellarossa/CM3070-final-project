using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Enemies.Infantry.StateMachine
{
    public class StateFactory
    {
        public InfantryControllerCore Parent { get; set; }
        public IInfantryState AttackState { get; protected set; }
        public IInfantryState IdleState { get; protected set; }

        public StateFactory(InfantryControllerCore parent)
        {
            this.Parent = parent;
            AttackState = new AttackState(this.Parent, this);
            IdleState = new IdleState(this.Parent, this);
        }
    }
}
