using System;

namespace FightShipArena.Assets.Scripts.Managers.HealthManagement
{
    public interface IHealthManager
    {
        event Action<int> HealthLevelChanged;
        event Action HasDied;

        int MaxHealth { get; set; }
        int Health { get; set; }
        bool IsInvulnerable { get; set; }
        void Heal(int byValue);
        void Heal();
        void Damage(int byValue);
        void Kill();
    }
}