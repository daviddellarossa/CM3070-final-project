using System;
using Codice.Client.GameUI.Explorer;
using FightShipArena.Assets.Scripts.Enemies.Infantry.StateMachine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public interface IEnemyState<T> 
        where T : IEnemyState<T>
    {
        event Action<T> ChangeState;

        void Move();
        void Rotate();
        void OnEnter();
        void OnExit();
    }
}
