using System;
using System.Collections;
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
        private Coroutine _spawningCoroutine;
        public event Action<int> SendScore;

        public GameObject PawnGO;
        public GameObject InfantryGO;

        public List<GameObject> SpawnPoints;

        public List<IEnemyControllerCore> Enemies { get; set; }

        void Awake()
        {
            Enemies = new List<IEnemyControllerCore>();
            SpawnPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));
        }

        void Start()
        {

        }

        public void StartSpawing()
        {
            if (_spawningCoroutine != null)
            {
                return;
            }

            _spawningCoroutine = StartCoroutine(StartSpawningAtTimeInterval());
        }
        public void StopSpawning()
        {
            if (_spawningCoroutine != null)
            {
                StopCoroutine(_spawningCoroutine);
                _spawningCoroutine = null;
            }
        }
        private IEnumerator StartSpawningAtTimeInterval()
        {
            yield return new WaitForSeconds(2.0f);

            while (true)
            {
                SpawnPawnAtRandomSpawnPoint();
                yield return new WaitForSeconds(1.0f);
            }
        }
        private void SpawnPawnAtRandomSpawnPoint()
        {
            var rndIndex = UnityEngine.Random.Range(0, SpawnPoints.Count);

            var spawnPoint = SpawnPoints[rndIndex];

            var newParticle = Instantiate(PawnGO, spawnPoint.transform.position, Quaternion.identity);
            var newParticleCore = newParticle.GetComponent<EnemyController>().Core;

            newParticleCore.HasDied += EnemyKilled;

            Enemies.Add(newParticleCore);
        }
        public void SpawnPawnAtPlayerCommand(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                SpawnPawnAtRandomSpawnPoint();
            }
        }

        public void EnemySpawned(GameObject obj)
        {
            var enemyCore = obj.GetComponent<EnemyController>().Core;

            enemyCore.HasDied += EnemyKilled;

            Enemies.Add(enemyCore);

        }

        private void EnemyKilled(IEnemyControllerCore obj)
        {
            SendScore?.Invoke(obj.InitSettings.PlayerScoreWhenKilled);

            obj.HasDied -= EnemyKilled;

            Debug.Assert(Enemies.Contains(obj), $"Enemy {obj.Parent.GameObject.name} not found in EnemyManager's Enemies collection");

            Enemies.Remove(obj);

        }

    }
}
