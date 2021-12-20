using System.Collections.Generic;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Weapons;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Player
{
    public interface IPlayerController
    {
        GameObject GameObject { get; }
        IPlayerControllerCore Core { get; set; }
        IHealthManager HealthManager { get; }
        WeaponBase[] Weapons { get; }
        public PlayerSettings InitSettings { get; }
    }
}