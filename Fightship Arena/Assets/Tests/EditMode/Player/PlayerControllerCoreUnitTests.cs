using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts;
using FightShipArena.Assets.Scripts.Managers.HealthManagement;
using FightShipArena.Assets.Scripts.Player;
using Moq;
using NUnit.Framework;
using UnityEngine;

namespace FightshipArena.Assets.Tests.EditMode.Player
{
    public class PlayerControllerCoreUnitTests
    {
        [Test]
        public void Constructor_initializes_parent_and_transform()
        {
            //arrange
            var gameObject = new GameObject();
            var monoBehaviourMock = new Mock<IPlayerController>();
            monoBehaviourMock
                .SetupGet(x => x.GameObject)
                .Returns(gameObject);

            var monoBehaviour = monoBehaviourMock.Object;

            var healthManagerMock = new Mock<IHealthManager>();
            var healthManager = healthManagerMock.Object;

            //act
            var core = new PlayerControllerCore(monoBehaviour);

            //assert
            Assert.That(core.Parent, Is.SameAs(monoBehaviour));
            Assert.That(core.Transform, Is.SameAs(gameObject.transform));
        }

        [Test]
        public void Move_adds_movement_to_position()
        {
            //arrange
            var gameObject = new GameObject();
            gameObject.transform.position = Vector3.zero;

            var monoBehaviourMock = new Mock<IPlayerController>();
            monoBehaviourMock
                .SetupGet(x => x.GameObject)
                .Returns(gameObject);

            var monoBehaviour = monoBehaviourMock.Object;

            var healthManagerMock = new Mock<IHealthManager>();
            var healthManager = healthManagerMock.Object;

            var core = new PlayerControllerCore(monoBehaviour);

            core.Movement = Vector3.one;

            //act
            core.Move();

            //assert
            Assert.That(gameObject.transform.position, Is.EqualTo(Vector3.one));

        }

    }
}
