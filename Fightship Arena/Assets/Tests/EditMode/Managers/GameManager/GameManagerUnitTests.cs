using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace FightshipArena.Assets.Tests.EditMode.Managers.GameManager
{
    public class GameManagerUnitTests
    {
        [UnityTest]
        public IEnumerator GameManager_instantiate_core_on_Start()
        {
            //arrange
            //act
            var gameManager =
                GameObject.FindObjectOfType<FightShipArena.Assets.Scripts.Managers.GameManager.GameManager>();

            yield return null;

            //assert
            Assert.That(gameManager.Core, Is.Not.Null);
        }
    }
}
