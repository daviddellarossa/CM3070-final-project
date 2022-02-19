namespace FightShipArena.Assets.Scripts.Managers.ScoreManagement
{
    public interface IScoreManager : IMyMonoBehaviour
    {
        void AddToHighScore();
        void AddToScore(int score);
        void AddToMultiplier(int multiplier);
        void ResetMultiplier();
        void ResetCurrentScore();
        void ResetHighScore();
    }
}
