using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.PowerUps
{
    [CreateAssetMenu(fileName = "New Power-Up InitSettings", menuName = "Power-Ups/Power-Up InitSettings")]
    public class PowerUpSettings : ScriptableObject
    {
        public PowerUpType PowerUpType;
        public float Value;
        public float Duration;
    }
}
