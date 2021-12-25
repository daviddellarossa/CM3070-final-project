using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.PowerUps.EnergyCharger
{
    public class EnergyCharger : PowerUpBase
    {
        void OnTriggerEnter2D(UnityEngine.Collider2D collision)
        {
            var playerGo = collision.gameObject;
            var playerController = playerGo.GetComponent<PlayerController>();
            playerController.Core.HealthManager.Heal((int)InitSettings.Value);
            GameObject.Destroy(this.GameObject);
        }

    }
}
