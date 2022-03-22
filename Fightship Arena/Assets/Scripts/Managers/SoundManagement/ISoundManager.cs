using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.SoundManagement
{
    public interface ISoundManager : IMyMonoBehaviour
    {
        AudioClip MenuMusic { get; }
        AudioClip GameMusic { get; }

        void PlayMusic(AudioClip audioClip);

        void PlaySound(Sound sound);
    }
}
