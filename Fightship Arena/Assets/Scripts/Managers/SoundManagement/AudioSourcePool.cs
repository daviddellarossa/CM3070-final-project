using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.SoundManagement
{
    public class AudioSourcePool
    {
        private ISoundManager _SoundManager;
        private int _DefaultPoolSize = 10;

        private List<AudioSource> audioSources = new List<AudioSource>();
        public int MaxPoolSize { get; set; }
        public AudioSourcePool(ISoundManager soundManager, int maxPoolSize)
        {
            if (soundManager == null)
                Debug.LogError("SoundManager is null");

            _SoundManager = soundManager ;

            if(MaxPoolSize <= 0)
            {
                Debug.LogWarning($"maxPoolSize must be greater than 0. Setting it to {_DefaultPoolSize}.");
                MaxPoolSize = _DefaultPoolSize;
            }
            MaxPoolSize = maxPoolSize;
        }

        public AudioSource GetAudioSource()
        {
            var audioSource = audioSources.FirstOrDefault(x=>x.isPlaying == false);

            if (audioSource == null)
            {
                if (audioSources.Count == MaxPoolSize)
                    return audioSources[(int)(UnityEngine.Random.value * audioSources.Count)];

                audioSource = _SoundManager.GameObject.AddComponent<AudioSource>();
                audioSources.Add(audioSource);
            }
            return audioSource;
        }
    }
}
