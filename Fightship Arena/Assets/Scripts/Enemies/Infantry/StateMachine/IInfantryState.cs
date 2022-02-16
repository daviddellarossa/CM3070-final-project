using System;

namespace FightShipArena.Assets.Scripts.Enemies.Infantry.StateMachine
{
    public interface IInfantryState : IEnemyState<IInfantryState>
    {
        InfantryControllerCore Parent { get; set; }
        StateFactory Factory { get; set; }
    }
}
