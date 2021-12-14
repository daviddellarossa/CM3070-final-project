using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public class PawnController : MyMonoBehaviour
    {
        public IEnemyControllerCore Core { get; set; }

        void Awake()
        {
            Core = new PawnControllerCore(this);
        }
    }
}
