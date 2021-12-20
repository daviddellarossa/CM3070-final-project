using System.Collections.Generic;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Player
{
    public interface IPlayerController
    {
        GameObject GameObject { get; }
        IPlayerControllerCore Core { get; set; }
        IHealthManager HealthManager { get; }
        WeaponBase[] Weapons { get; }
        PlayerSettings InitSettings { get; }

        void OnMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnFireAlt(InputAction.CallbackContext context);
        void OnOpenSelectionMenu(InputAction.CallbackContext context);

    }
}