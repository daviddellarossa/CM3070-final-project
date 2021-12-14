using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public interface IEnemyControllerCore
    {
        public int Strenght { get; set; }
        public int Health { get; set; }
    }
}
