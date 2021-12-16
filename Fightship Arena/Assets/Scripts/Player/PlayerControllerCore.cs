using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Player
{
    public class PlayerControllerCore : IPlayerControllerCore
    {
        public Vector3 Movement { get; set; }

        public IMyMonoBehaviour Parent { get; protected set; }

        public Transform Transform { get; protected set; }

        public PlayerControllerCore(IMyMonoBehaviour parent)
        {
            Parent = parent;
            Transform = parent.GameObject.transform;
        }
        public void Move()
        {
            Transform.position += Movement;
        }

        public void Fire()
        {
           
        }

        public void FireAlt()
        {

        }

        public void OpenSelectionMenu()
        {

        }
    }
}
