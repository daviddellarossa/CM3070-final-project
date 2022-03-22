using System.Linq;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Weapons;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public abstract class EnemyController : MyMonoBehaviour, IEnemyController
    {
        protected EnemySoundManager _SoundManager;

        [SerializeField] private EnemySettings _initSettings;
        public IEnemyControllerCore Core { get; set; }
        public IHealthManager HealthManager { get; set; }
        public WeaponBase[] Weapons { get; set; }
        public EnemySettings InitSettings { get => _initSettings; }

        public GameObject ExplosionEffect;

        public GameObject SpawnActivationEffect;

        protected virtual void ReleasePowerUp()
        {
            if (!_initSettings.Powerups.Any())
            {
                return;
            }

            var value = (UnityEngine.Random.value * _initSettings.Powerups.Count) % _initSettings.Powerups.Count;
            var index = Mathf.FloorToInt(value);

            var selectedPowerUp = _initSettings.Powerups[index];
            if (selectedPowerUp.ReleaseRate < value - index)
            {
                return;
            }

            var instance = GameObject.Instantiate(selectedPowerUp.PowerUp);
            UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(instance, UnityEngine.SceneManagement.SceneManager.GetSceneAt(1));

            instance.transform.parent = null;
            instance.transform.position = this.transform.position;
        }
    }
}