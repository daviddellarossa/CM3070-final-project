using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace FightshipArena.Assets.Tests.PlayMode.Player
{
    public class PlayerControllerUnitTests
    {
        [UnityTest]
        public IEnumerator Player_instantiate_core_on_Start()
        {
            //arrange
            //act
            var gameObject = new GameObject("Player");
            var playerController = gameObject.AddComponent<PlayerController>();

            yield return null;

            //assert
            Assert.That(playerController.Core, Is.Not.Null);
        }

    }
}
