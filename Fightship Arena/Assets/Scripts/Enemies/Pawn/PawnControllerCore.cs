using System;
using FightShipArena.Assets.Scripts.Enemies.Pawn.StateMachine;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Player;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Enemies.Pawn
{
    public class PawnControllerCore : IEnemyControllerCore
    {
        public event Action<IEnemyControllerCore> HasDied;

        public IPlayerControllerCore PlayerControllerCore { get; set; }
        public IEnemyController Parent { get; protected set; }
        public Transform Transform { get; protected set; }
        public Rigidbody2D Rigidbody { get; protected set; }
        public EnemySettings InitSettings { get; protected set; }
        public IHealthManager HealthManager { get; }

        public IPawnState CurrentState { get; protected set; }
        private StateFactory _stateFactory;

        public PawnControllerCore(IEnemyController parent, IHealthManager healthManager, EnemySettings settings)
        {
            Parent = parent;
            Transform = parent.GameObject.transform;
            Rigidbody = parent.GameObject.GetComponent<Rigidbody2D>();
            HealthManager = healthManager;
            HealthManager.HasDied += HealthManager_HasDied;
            HealthManager.HealthLevelChanged += HealthManager_HealthLevelChanged;

            InitSettings = settings;

            _stateFactory = new StateFactory(this);
            CurrentState = _stateFactory.IdleState;

        }

        private void HealthManager_HealthLevelChanged(int value, int maxValue) { }

        private void HealthManager_HasDied()
        {
            ChangeState(_stateFactory.IdleState);
            HasDied?.Invoke(this);
        }

        public void OnStart()
        {
            if(PlayerControllerCore != null)
            {
                PlayerControllerCore.HealthManager.HasDied += Player_HasDied;
                ChangeState(_stateFactory.SeekState);
            }
            else
            {
                ChangeState(_stateFactory.IdleState);
            }

        }

        private void Player_HasDied()
        {
            ChangeState(_stateFactory.IdleState);
        }

        protected void ChangeState(IPawnState newState)
        {
            if (CurrentState != null)
            {
                CurrentState.OnExit();
                CurrentState.ChangeState -= CurrentStateOnChangeState;
            }

            if (CurrentState == newState)
            {
                return;
            }

            CurrentState = newState;
            CurrentState.ChangeState += CurrentStateOnChangeState;
            CurrentState.OnEnter();
        }

        private void CurrentStateOnChangeState(IPawnState state)
        {
            ChangeState(state);
        }

        public void Move()
        {
            CurrentState.Move();
            CurrentState.Rotate();
        }

        public void HandleCollisionWithPlayer()
        {
            HealthManager.Kill();
        }

    }
}
