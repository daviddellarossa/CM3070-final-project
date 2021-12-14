using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public class PawnControllerCore : IEnemyControllerCore
    {
        public readonly IMyMonoBehaviour Parent;

        public PawnControllerCore(IMyMonoBehaviour parent)
        {
            Parent = parent;
        }

        public int Strenght { get; set; }
        public int Health { get; set; }
    }
}
