using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Weapons
{
    [CreateAssetMenu(fileName = "New Weapon InitSettings", menuName = "Weapons/Weapon InitSettings")]
    public class WeaponSettings : ScriptableObject
    {
        public int MagazineCapacity;
        public int Ammo;
        public float RateOfFire;

    }
}
