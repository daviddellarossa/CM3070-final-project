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
        public readonly IMyMonoBehaviour Parent;
        public readonly Transform Transform;
        public Vector3 Movement { get; set; }


        public PlayerControllerCore(IMyMonoBehaviour parent)
        {
            Parent = parent;
            Transform = parent.GameObject.transform;
        }
        public void Move()
        {
            //Debug.Log($"Moving by {Movement}");
            Transform.position += Movement;
        }
    }
}
