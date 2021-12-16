using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Player
{
    [CreateAssetMenu(fileName = "New Player settings", menuName = "Player/Player Settings")]
    public class PlayerSettings : ScriptableObject
    {
        public int InitHealth;
    }
}
