﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Weapons;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Player
{
    [CreateAssetMenu(fileName = "New Player settings", menuName = "Player/Player InitSettings")]
    public class PlayerSettings : ScriptableObject
    {
        public int InitHealth;
        public int DamageAppliedOnCollision;
        [Range(0, 10)]
        public float MaxSpeed;
        [Range(0, 1)]
        public float Deceleration;
        public float ForceMultiplier;
        public List<WeaponSettings> WeaponSettings;
    }
}
