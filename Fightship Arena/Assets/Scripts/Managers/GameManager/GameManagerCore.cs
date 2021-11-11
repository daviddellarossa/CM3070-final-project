namespace FightShipArena.Assets.Scripts.Managers.GameManager
{
    public class GameManagerCore : IGameManagerCore
    {
        public readonly IMyMonoBehaviour Parent;

        public GameManagerCore(IMyMonoBehaviour parent)
        {
            Parent = parent;

        }
    }
}
