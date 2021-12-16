using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    [CreateAssetMenu(fileName = "New Enemy Type", menuName = "Enemy/Enemy Type")]
    public class EnemyType : ScriptableObject
    {
        public TypeEnum Type;
        public float MaxSpeed;
        public float MinAttractiveForceMagnitude;
        public float MaxAttractiveForceMagnitude;
        public float MinMovementMagnitude;
        public float MaxMovementMagnitude;
        public float MaxHealth;
    }

    public enum TypeEnum
    {
        Pawn
    }
}
