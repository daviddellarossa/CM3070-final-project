using System;
using System.Collections;
using System.Linq;
using FightShipArena.Assets.Scripts.Enemies.Infantry.StateMachine;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Player;
using FightShipArena.Assets.Scripts.Weapons;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FightShipArena.Assets.Scripts.Enemies.Infantry
{
    public class InfantryControllerCore : IEnemyControllerCore
    {
        public IPlayerControllerCore PlayerControllerCore { get; set; }
        public IEnemyController Parent { get; protected set; }
        public Transform Transform { get; protected set; }
        public Rigidbody2D Rigidbody { get; protected set; }
        public EnemySettings InitSettings { get; protected set; }
        public IHealthManager HealthManager { get; }
        public WeaponBase[] Weapons { get; }
        public WeaponBase CurrentWeapon { get; set; }

        //public EnemyState State__ { get; set; }

        public IInfantryState CurrentState { get; protected set; }
        private StateFactory _stateFactory;


        public event Action<IEnemyControllerCore> HasDied;

        public InfantryControllerCore(IEnemyController parent, IHealthManager healthManager, EnemySettings settings)
        {
            //State = EnemyState.Idle;
            Parent = parent;
            Transform = parent.GameObject.transform;
            Rigidbody = parent.GameObject.GetComponent<Rigidbody2D>();
            HealthManager = healthManager;
            HealthManager.HasDied += HealthManager_HasDied;
            HealthManager.HealthLevelChanged += HealthManager_HealthLevelChanged;

            InitSettings = settings;
            Weapons = parent.Weapons.Select(x => x.GetComponent<WeaponBase>()).ToArray();
            CurrentWeapon = Weapons[0];

            _stateFactory = new StateFactory(this);


            //var mb = parent.StartCoroutine(Attack());
        }

        private void Player_HasDied()
        {
            ChangeState(_stateFactory.IdleState);
        }

        private void HealthManager_HealthLevelChanged(int obj) { }

        private void HealthManager_HasDied()
        {
            HasDied?.Invoke(this);
        }

        public void HandleCollisionWithPlayer()
        {
            HealthManager.Kill();
        }

        public void Move()
        {
            CurrentState.Move();
            CurrentState.Rotate();
        }

        public void OnStart()
        {
            PlayerControllerCore.HealthManager.HasDied += Player_HasDied; 
            ChangeState(_stateFactory.IdleState);
        }

        protected void ChangeState(IInfantryState newState)
        {
            if (CurrentState != null)
            {
                CurrentState.OnExit();
                CurrentState.ChangeState -= CurrentStateOnChangeState;
            }

            CurrentState = newState;
            CurrentState.ChangeState += CurrentStateOnChangeState;
            CurrentState.OnEnter();
        }

        private void CurrentStateOnChangeState(IInfantryState state)
        {
            ChangeState(state);
        }
    }
}
