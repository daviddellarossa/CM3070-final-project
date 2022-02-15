using System;

namespace FightShipArena.Assets.Scripts.Enemies.Infantry.StateMachine
{
    public interface IInfantryState : IEnemyState
    {
        event Action<IInfantryState> ChangeState;
        InfantryControllerCore Parent { get; set; }
        StateFactory Factory { get; set; }
    }
}
