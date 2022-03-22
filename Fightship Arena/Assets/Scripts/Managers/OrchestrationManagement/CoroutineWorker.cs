using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    public class CoroutineWorker : MonoBehaviour
    {
        public void Work(IEnumerator _coroutine)
        {
            StartCoroutine(WorkCoroutine(_coroutine));
        }

        private IEnumerator WorkCoroutine(IEnumerator _coroutine)
        {
            yield return StartCoroutine(_coroutine);
            Destroy(this.gameObject);
        }
    }
}
