using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Weapons;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public interface IEnemyController : IMyMonoBehaviour
    {
        EnemySettings InitSettings { get; }
        GameObject GameObject { get; }
        IEnemyControllerCore Core { get; set; }
        IHealthManager HealthManager { get; set; }
        WeaponBase[] Weapons { get; set; }
    }
}