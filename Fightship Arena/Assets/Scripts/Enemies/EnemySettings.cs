using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    [CreateAssetMenu(fileName = "New Enemy Settings", menuName = "Enemy/Enemy Settings")]
    public class EnemySettings : ScriptableObject
    {
        public EnemyType EnemyType;
        public float MaxSpeed;
        public float MinAttractiveForceMagnitude;
        public float MaxAttractiveForceMagnitude;
        public float MinMovementMagnitude;
        public float MaxMovementMagnitude;
        public float InitHealth;
        public int DamageAppliedOnCollision;
    }

    public enum EnemyType
    {
        Pawn
    }
}
