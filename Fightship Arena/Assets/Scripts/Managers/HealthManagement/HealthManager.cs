using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.HealthManagement
{
    public class HealthManager : IHealthManager
    {
        public event Action<int, int> HealthLevelChanged;
        public event Action HasDied;

        public int MaxHealth { get; set; }
        private int _health;

        public int Health
        {
            get => _health;
            set
            {
                //if (value == _health)
                //{
                //    return;
                //}

                _health = value;

                HealthLevelChanged?.Invoke(_health, MaxHealth);

                if (_health <= 0)
                {
                    HasDied?.Invoke();
                }
            }
        }
        public bool IsInvulnerable { get; set; }
        public bool IsDead { get; protected set;
        }

        public void Heal(int byValue)
        {
            var newHealthValue =  Health + byValue;
            if (newHealthValue > MaxHealth)
            {
                newHealthValue = MaxHealth;
            }

            Health = newHealthValue;

        }

        public void Heal()
        {
            Heal(MaxHealth);
            IsDead = false;
        }

        public void Damage(int byValue)
        {
            if (IsInvulnerable) return;

            var newHealthValue = Health - byValue;
            if (newHealthValue < 0)
            {
                newHealthValue = 0;
            }

            Health = newHealthValue;
        }

        public void Kill()
        {
            Damage(Health);
        }

        public HealthManager(int health, int maxHealth, bool isInvulnerable)
        {
            this.Health = health;
            this.MaxHealth = maxHealth;
            this.IsInvulnerable = isInvulnerable;
        }

    }
}
