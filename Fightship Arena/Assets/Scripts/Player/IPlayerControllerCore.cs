using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Player
{
    public interface IPlayerControllerCore
    {
        Vector3 Movement { get; set; }
        IMyMonoBehaviour Parent { get; }
        Transform Transform { get; }

        void Move();
        void Fire();
        void FireAlt();
        void OpenSelectionMenu();
    }
}
