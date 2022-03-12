using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.SoundManagement
{
    [System.Serializable]
    public class Sound
    {
        public string Name;
        public AudioClip Clip;
        [Range(0f, 1f)]
        public float Volume;
    }
}
