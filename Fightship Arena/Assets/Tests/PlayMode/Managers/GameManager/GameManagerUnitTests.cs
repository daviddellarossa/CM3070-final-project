using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace FightshipArena.Assets.Tests.PlayMode.Managers.GameManager
{
    public class GameManagerUnitTests
    {
        [UnityTest]
        public IEnumerator GameManager_instantiate_core_on_Start()
        {
            //arrange
            //act
            var gameObject = new GameObject("Player");
            var gameManager = gameObject.AddComponent<FightShipArena.Assets.Scripts.Managers.GameManager.GameManager>();

            yield return null;

            //assert
            Assert.That(gameManager.Core, Is.Not.Null);
        }
    }
}
