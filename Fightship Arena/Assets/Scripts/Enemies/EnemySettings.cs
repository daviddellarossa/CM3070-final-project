using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    [CreateAssetMenu(fileName = "New Enemy InitSettings", menuName = "Enemy/Enemy InitSettings")]
    public class EnemySettings : ScriptableObject
    {
        public EnemyType EnemyType;
        public float MaxSpeed;
        public float MinAttractiveForceMagnitude;
        public float MaxAttractiveForceMagnitude;
        public float MinMovementMagnitude;
        public float MaxMovementMagnitude;
        public int InitHealth;
        public int DamageAppliedOnCollision;
        public bool InvulnerableAtStart;
        public float InvulnerableAtStartForSeconds;
        public List<EnemyPowerUp> Powerups;
        public int PlayerScoreWhenKilled;
    }
}
