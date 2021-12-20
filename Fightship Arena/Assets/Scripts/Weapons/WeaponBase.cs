using System;
using System.Collections;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Weapons
{
    public abstract class WeaponBase : MyMonoBehaviour
    {
        public WeaponType WeaponType;
        public WeaponSettings InitSettings;
        public GameObject Bullet;
        private Coroutine _fireCoroutine;

        public int Ammo;
        void Awake()
        {
            if (InitSettings == null)
            {
                throw new NullReferenceException($"InitSettings cannot be null for Weapon {this.GetType().Name}");
            }

            if (Bullet == null)
            {
                throw new NullReferenceException($"Bullet cannot be null for Weapon {this.GetType().Name}");
            }

            var bulletScript = Bullet.GetComponent<BulletBase>();

            if (bulletScript.InitSettings.WeaponType != WeaponType)
            {
                throw new Exception(
                    $"Bullet of type {bulletScript.InitSettings.WeaponType.ToString()} not compatible with Weapon of type {WeaponType}");
            }
            Ammo = InitSettings.Ammo;

        }

        public virtual void StartFiring()
        {
            _fireCoroutine = StartCoroutine(Fire());
        }

        public virtual void StopFiring()
        {
            if (_fireCoroutine != null)
            {
                StopCoroutine(_fireCoroutine);
            }

            _fireCoroutine = null;
        }

        private IEnumerator Fire()
        {
            bool onlyOnce = InitSettings.RateOfFire == 0;

            var delta = 1.0f / InitSettings.RateOfFire;

            while (Ammo > 0)
            {
                var bulletGo = GameObject.Instantiate(this.Bullet, this.transform);
                bulletGo.transform.parent = null;
                Ammo--;

                if (onlyOnce) yield break;
                yield return new WaitForSeconds(delta);
            }
        }
    }
}
