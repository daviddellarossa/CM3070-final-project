using FightShipArena.Assets.Scripts.Managers.SceneManagement;
using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.Menus
{
    public class MenuButtonManager : MyMonoBehaviour
    {
        [SerializeField]
        private Sound HoverSound;

        [SerializeField]
        private Sound ClickSound;


        [SerializeField]
        private SceneManager SceneManager;

        public void PlayHoverSound()
        {
            SceneManager.PlaySound(HoverSound);
        }
        public void PlayClickSound()
        {
            SceneManager.PlaySound(ClickSound);
        }

    }
}
