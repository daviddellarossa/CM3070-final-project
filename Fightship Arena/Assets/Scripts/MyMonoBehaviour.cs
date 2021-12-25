using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine;

namespace FightShipArena.Assets.Scripts
{
    public class MyMonoBehaviour : MonoBehaviour, IMyMonoBehaviour
    {
        public virtual GameObject GameObject => base.gameObject;
    }
}
