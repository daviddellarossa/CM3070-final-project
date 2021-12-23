using System;
using System.Collections.Generic;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.ScoreManagement
{
    public class ScoreManager : MyMonoBehaviour, IScoreManager
    {
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
        }

        public void AddToScore(int score)
        {
            CurrentScore.Value += score * Multiplier;
        }

        public void AddMultiplier(int multiplier)
        {
            Multiplier += multiplier;
            Debug.Log($"Multiplier set to {Multiplier}");
        }

        public void ResetMultiplier()
        {
            Multiplier = 1;
        }

        public void ResetCurrentScore()
        {
            CurrentScore = new Score();
        }

        public void ResetHighScore()
        {
            HighScores.HighScores.Clear();
        }
    }
}
