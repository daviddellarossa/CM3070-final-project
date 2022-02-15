using Codice.Client.GameUI.Explorer;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public interface IEnemyState
    {
        void Move();
        void Rotate();

        void OnEnter();
        void OnExit();
    }
}
