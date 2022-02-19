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

        private Score CurrentScore;

        public HighScoreRecorder HighScores;

        private int _multiplier;
        public int Multiplier
        {
            get => _multiplier;
            protected set
            {
                if (value == _multiplier)
                {
                    return;
                }

                _multiplier = value;
                Debug.Log($"Multiplier set to {Multiplier}");
                NotifyMultiplierValueChange();
            }
        }

        void Start()
        {
            ResetCurrentScore();
            ResetMultiplier();
            NotifyHighScoreValueChange();

        }

        private void NotifyHighScoreValueChange()
        {
            var highScore = HighScores.HighScores.OrderByDescending(x => x.Value).FirstOrDefault();
            int highScoreValue = 0;
            if (highScore != null)
            {
                highScoreValue = highScore.Value;
            }

            HiScoreChanged.Invoke(highScoreValue);
        }

        private void NotifyScoreValueChange()
        {
            ScoreChanged?.Invoke(CurrentScore.Value);
        }

        private void NotifyMultiplierValueChange()
        {
            MultiplierChanged?.Invoke(Multiplier);
        }


        public void AddToHighScore()
        {
            if (CurrentScore.Value == 0)
            {
                return;
            }
            CurrentScore.Date = DateTime.Now.ToString("s");
            CurrentScore.Name = "DDR";
            HighScores.HighScores.Add(CurrentScore);
            NotifyHighScoreValueChange();
        }

        public void AddToScore(int score)
        {
            var totScore = score * Multiplier;
            CurrentScore.Value += totScore;
            Debug.Log($"Score set to {CurrentScore.Value}");
            NotifyScoreValueChange();
        }

        public void AddToMultiplier(int multiplier)
        {
            Multiplier += multiplier;
        }

        public void ResetMultiplier()
        {
            Multiplier = 1;
        }

        public void ResetCurrentScore()
        {
            CurrentScore = new Score();
            NotifyScoreValueChange();

        }

        public void ResetHighScore()
        {
            HighScores.HighScores.Clear();
            HiScoreChanged?.Invoke(HighScores.HighScores.OrderByDescending(x => x.Value).Select(x => x.Value).FirstOrDefault());

        }
    }
}
