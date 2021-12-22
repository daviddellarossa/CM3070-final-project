using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Weapons
{
    public abstract class BulletBase : MyMonoBehaviour
    {
        public WeaponType WeaponType;
        public BulletSettings InitSettings;
        public bool IsDestroyed = false;

        void Awake()
        {
            if (InitSettings == null)
            {
                throw new NullReferenceException("BulletSetting cannot be null");
            }

            if (InitSettings.WeaponType != WeaponType)
            {
                throw new Exception(
                    $"Bullet Settings of type {InitSettings.WeaponType.ToString()} not compatible with Bullet of type {WeaponType}");
            }
        }
    }
}
