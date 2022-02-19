using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.HudManagement
{
    public class HudManager : MyMonoBehaviour, IHudManager
    {
        [SerializeField] private TextMeshProUGUI HiScore;
        [SerializeField] private TextMeshProUGUI Score;
        [SerializeField] private TextMeshProUGUI Multiplier;
        public void SetHiScore(int value)
        {
            HiScore.text = value.ToString();
        }

        public void SetScore(int value)
        {
            Score.text = value.ToString();
        }

        public void SetMultiplier(int value)
        {
            Multiplier.text = value.ToString();
        }
    }
}
