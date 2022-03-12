using FightShipArena.Assets.Scripts.Managers.SceneManagement;
using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Weapons
{
    public class WeaponSoundManager : MyMonoBehaviour
    {
        [SerializeField]
        private Sound FireSound;

        private SceneManager SceneManager;

        private void Start()
        {
            var sceneManagerGo = GameObject.FindGameObjectWithTag("SceneManager");
            SceneManager = sceneManagerGo?.GetComponent<SceneManager>();

            if(SceneManager == null)
            {
                throw new Exception("SceneManager not found");
            }
        }

        public void PlayFireSound()
        {
            SceneManager.PlaySound(FireSound);
        }
    }
}
