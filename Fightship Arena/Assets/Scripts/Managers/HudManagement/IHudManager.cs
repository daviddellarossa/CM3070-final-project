using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.HudManagement
{
    public interface IHudManager
    {
        void SetHiScore(int value);
        void SetScore(int value);
        void SetMultiplier(int value);
        void SetHealth(int value, int maxValue);
    }
}
