using FightShipArena.Assets.Scripts.Managers.SceneManagement;
using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public class EnemySoundManager : MyMonoBehaviour
    {
        [SerializeField]
        private Sound MoveSound;

        [SerializeField]
        private Sound ExplodeSound;

        [SerializeField]
        private Sound HitSound;

        public SceneManager SceneManager;

        public void PlayMoveSound()
        {
            SceneManager.PlaySound(MoveSound);
        }
        
        public void PlayExplodeSound()
        {
            SceneManager.PlaySound(ExplodeSound);
        }

        public void PlayHitSound()
        {
            SceneManager.PlaySound(HitSound);
        }

    }
}
