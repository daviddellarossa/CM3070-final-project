using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.EnemyManagement
{
    public class EnemyManager : MyMonoBehaviour
    {
        public GameObject PawnGO;

        public void SpawnPawnAtRandomLocation(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                var cam = GameObject.FindObjectOfType<Camera>();

                Vector3 randomSpawnPosition = GetRandomSpawnPoint(cam.pixelRect, -cam.transform.position.z);

                var point = cam.ScreenToWorldPoint(randomSpawnPosition);

                var newParticle = Instantiate(PawnGO, point, Quaternion.identity);
            }
        }

        private Vector3 GetRandomSpawnPoint(Rect box, float z)
        {
            var point = new Vector3(
                UnityEngine.Random.value * box.width,
                UnityEngine.Random.value * box.height,
                z
            );
            return point;
        }
    }
}
