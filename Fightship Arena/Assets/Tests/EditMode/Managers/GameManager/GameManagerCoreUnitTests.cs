using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts;
using FightShipArena.Assets.Scripts.Managers.GameManagement;
using FightShipArena.Assets.Scripts.Player;
using Moq;
using NUnit.Framework;
using UnityEngine;

namespace FightshipArena.Assets.Tests.EditMode.Managers.GameManager
{
    public class GameManagerCoreUnitTests
    {
        [Test]
        public void Constructor_initializes_parent()
        {
            //arrange
            var gameObject = new GameObject();
            var monoBehaviourMock = new Mock<IMyMonoBehaviour>();
            monoBehaviourMock
                .SetupGet(x => x.GameObject)
                .Returns(gameObject);

            var monoBehaviour = monoBehaviourMock.Object;

            //act
            var core = new GameManagerCore(monoBehaviour);

            //assert
            Assert.That(core.Parent, Is.SameAs(monoBehaviour));
        }
    }
}
