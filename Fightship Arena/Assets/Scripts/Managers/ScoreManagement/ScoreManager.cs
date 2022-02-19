using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace FightShipArena.Assets.Scripts.Managers.ScoreManagement
{
    public class ScoreManager : MyMonoBehaviour, IScoreManager
    {
        public UnityEvent<int> ScoreChanged;
        public UnityEvent<int> MultiplierChanged;
        public UnityEvent<int> HiScoreChanged;
        public Score CurrentScore;
        public HighScoreRecorder HighScores;
        public int Multiplier = 1;

        void Start()
        {
            ResetCurrentScore();
        }

        public void AddToHighScore()
        {
            CurrentScore.Date = DateTime.Now.ToString("s");
            CurrentScore.Name = "DDR";
            HighScores.HighScores.Add(CurrentScore);
            HiScoreChanged?.Invoke(HighScores.HighScores.OrderByDescending(x=>x.Value).Select(x=>x.Value).FirstOrDefault());
        }

        public void AddToScore(int score)
        {
            var totScore = score * Multiplier;
            CurrentScore.Value += totScore;
            ScoreChanged?.Invoke(CurrentScore.Value);
            Debug.Log($"Adding score {totScore}");
        }

        public void AddMultiplier(int multiplier)
        {
            Multiplier += multiplier;
            MultiplierChanged?.Invoke(Multiplier);
            Debug.Log($"Multiplier set to {Multiplier}");
        }

        public void ResetMultiplier()
        {
            Multiplier = 1;
            MultiplierChanged?.Invoke(Multiplier);

        }

        public void ResetCurrentScore()
        {
            CurrentScore = new Score();
            ScoreChanged?.Invoke(CurrentScore.Value);

        }

        public void ResetHighScore()
        {
            HighScores.HighScores.Clear();
            HiScoreChanged?.Invoke(HighScores.HighScores.OrderByDescending(x => x.Value).Select(x => x.Value).FirstOrDefault());

        }
    }
}
