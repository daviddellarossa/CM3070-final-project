using System.Linq;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Weapons;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies
{
    public abstract class EnemyController : MyMonoBehaviour, IEnemyController
    {
        public EnemySettings InitSettings;
        public IEnemyControllerCore Core { get; set; }
        public IHealthManager HealthManager { get; set; }
        public WeaponBase[] Weapons { get; set; }

        protected virtual void ReleasePowerUp()
        {
            if (!InitSettings.Powerups.Any())
            {
                return;
            }

            var value = (UnityEngine.Random.value * InitSettings.Powerups.Count) % InitSettings.Powerups.Count;
            var index = Mathf.FloorToInt(value);

            var selectedPowerUp = InitSettings.Powerups[index];
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