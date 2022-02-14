using System.Collections;
using UnityEngine;
using UnityEngine.Internal;

namespace FightShipArena.Assets.Scripts
{
    public interface IMyMonoBehaviour
    {
        GameObject GameObject { get; }
        Coroutine StartCoroutine(IEnumerator routine);
        Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value);
        void StopCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine routine);

    }

}
