using FightShipArena.Assets.Scripts.Managers.SoundManagement;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.SceneManagement
{
    public class SceneManager : MyMonoBehaviour, IMyMonoBehaviour
    {
        void Start()
        {
            Debug.Log("Scene started");

        }

        public virtual void PlaySound(Sound sound) { }
    }
}
