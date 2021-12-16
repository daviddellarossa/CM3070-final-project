using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Player
{

    public interface IPlayerController
    {
        event Action HasDied;
    }

    public interface IPlayerControllerCore : IPlayerController
    {


        Vector3 Movement { get; set; }
        IMyMonoBehaviour Parent { get; }
        Transform Transform { get; }
        int Health { get; set; }

        void Start(PlayerSettings settings);
        void Move();
        void Fire();
        void FireAlt();
        void OpenSelectionMenu();

        void InflictDamage(int damage);
    }
}
