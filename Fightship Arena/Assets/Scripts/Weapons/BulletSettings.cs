using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Weapons
{
    [CreateAssetMenu(fileName = "New Bullet InitSettings", menuName = "Weapons/Bullet InitSettings")]
    public class BulletSettings : ScriptableObject
    {
        public WeaponType WeaponType;
        public float Speed;
        public int Damage;
        public float Scale;
    }
}
