using System;

namespace FightShipArena.Assets.Scripts.Enemies.Pawn.StateMachine
{
    public interface IPawnState : IEnemyState
    {
        event Action<IPawnState> ChangeState;
        PawnControllerCore Parent { get; set; }
        StateFactory Factory { get; set; }
    }
}