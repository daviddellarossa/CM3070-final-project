namespace FightShipArena.Assets.Scripts.Managers.GameManagement
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
