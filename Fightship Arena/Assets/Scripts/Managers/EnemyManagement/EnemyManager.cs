using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Enemies;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace FightShipArena.Assets.Scripts.Managers.EnemyManagement
{
    public class EnemyManager : MyMonoBehaviour, IEnemyManager
    {
        public event Action<int> SendScore;

        public GameObject PawnGO;

        public List<IEnemyControllerCore> Enemies { get; set; }

        void Awake()
        {
            Enemies = new List<IEnemyControllerCore>();
        }
        public void SpawnPawnAtRandomLocation(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                var cam = GameObject.FindObjectOfType<Camera>();

                Vector3 randomSpawnPosition = GetRandomSpawnPoint(cam.pixelRect, -cam.transform.position.z);

                var point = cam.ScreenToWorldPoint(randomSpawnPosition);

                var newParticle = Instantiate(PawnGO, point, Quaternion.identity);
                var newParticleCore = newParticle.GetComponent<EnemyController>().Core;

                newParticleCore.HasDied += EnemyKilled;

                Enemies.Add(newParticleCore);
            }
        }

        private void EnemyKilled(IEnemyControllerCore obj)
        {
            SendScore?.Invoke(obj.InitSettings.PlayerScoreWhenKilled);

            obj.HasDied -= EnemyKilled;

            Debug.Assert(Enemies.Contains(obj), $"Enemy {obj.Parent.GameObject.name} not found in EnemyManager's Enemies collection");

            Enemies.Remove(obj);

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
