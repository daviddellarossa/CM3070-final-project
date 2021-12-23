using System;
using System.Collections.Generic;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.ScoreManagement
{
    [CreateAssetMenu(fileName = "High score", menuName = "Score/High Score")]

    public class HighScoreRecorder : ScriptableObject
    {
        public List<Score> HighScores;

    }
}
