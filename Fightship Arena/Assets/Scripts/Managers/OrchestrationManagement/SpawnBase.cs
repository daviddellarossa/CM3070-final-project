using System;
using System.Collections;
using FightShipArena.Assets.Scripts.Managers.OrchestrationManagement.Conditions;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.OrchestrationManagement
{
    public abstract class SpawnBase : ScriptableObject
    {
        public abstract event Action<GameObject> EnemySpawned;
        public abstract event Action<GameObject> EnemyKilled;
        public abstract event Action<SpawnBase, OrchestrationState> StateChanged;
        public ConditionBase StartCondition;
        public OrchestrationState State { get; protected set; }
        public abstract void Execute();
        public abstract void CancelExecution();

        protected virtual void ChangeState(OrchestrationState newState)
        {
        }

        protected void StartCoroutine(IEnumerator task)
        {

            if (!Application.isPlaying)
            {
                Debug.LogError("Can not run coroutine outside of play mode.");
                return;
            }

            var coworker = new GameObject("CoWorker_" + task.ToString()).AddComponent<CoroutineWorker>();
            UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(coworker.gameObject, UnityEngine.SceneManagement.SceneManager.GetSceneAt(1));

            coworker.Work(task);
        }
    }
}