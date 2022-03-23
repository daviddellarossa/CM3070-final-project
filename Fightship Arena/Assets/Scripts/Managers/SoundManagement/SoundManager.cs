using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.SoundManagement
{
    public class SoundManager : MyMonoBehaviour, ISoundManager
    {
        [SerializeField]
        private AudioClip _MenuMusic;
        [SerializeField]
        private AudioClip _GameMusic;
        public AudioClip MenuMusic => _MenuMusic;
        public AudioClip GameMusic => _GameMusic;

        private AudioSource _MusicSource;

        private AudioSourcePool _AudioSourcePool;

        [SerializeField]
        private int _AudioSourcePoolSize = 10;

        void Awake()
        {
            _AudioSourcePool = new AudioSourcePool(this, _AudioSourcePoolSize);

            _MusicSource = gameObject.AddComponent<AudioSource>();
            _MusicSource.loop = true;
        }
        public void PlayMusic(AudioClip audioClip)
        {
            _MusicSource.clip = audioClip;
            _MusicSource.volume = 0.1f;
            _MusicSource.Play();
        }

        public void PlaySound(AudioClip audioClip)
        {
            var audioSource = _AudioSourcePool.GetAudioSource();
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public void PlaySound(Sound sound)
        {
            var audioSource = _AudioSourcePool.GetAudioSource();
            audioSource.clip = sound.Clip;
            audioSource.volume = sound.Volume;
            audioSource.Play();
        }
    }
}
