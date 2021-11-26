using FightShipArena.Assets.Scripts;
using FightShipArena.Assets.Scripts.Managers.GameManagement;
using FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine;
using Moq;
using NUnit.Framework;

namespace FightshipArena.Assets.Tests.EditMode.Managers.GameManagement.StateMachine
{
    [TestFixture]
    public class StateUnitTests
    {
        [Test]
        public void Constructor_assign_gameManager_input_parameter_to_GameManager_property()
        {
            //arrange
            var gameManagerCoreMock = new Mock<IGameManagerCore>();
            var gameManagerCore = gameManagerCoreMock.Object;

            var stateMock = new Mock<State>(gameManagerCore);
            stateMock.CallBase = true;

            //act
            var state = stateMock.Object;
            
            //assert
            Assert.That(state.GameManager, Is.SameAs(gameManagerCore));
        }

        [Test]
        public void OnConstruction_StateState_is_initialised_to_NotInStack()
        {
            //arrange
            var gameManagerCoreMock = new Mock<IGameManagerCore>();
            var gameManagerCore = gameManagerCoreMock.Object;

            var stateMock = new Mock<State>(gameManagerCore);
            stateMock.CallBase = true;

            //act
            var state = stateMock.Object;

            //assert
            Assert.That(state.StateState, Is.EqualTo(StateStateEnum.NotInStack));
        }

        [Test]
        public void OnEnter_set_stateState_to_InStack()
        {
            //arrange
            var gameManagerCoreMock = new Mock<IGameManagerCore>();
            var gameManagerCore = gameManagerCoreMock.Object;

            var stateMock = new Mock<State>(gameManagerCore);
            stateMock.CallBase = true;

            var state = stateMock.Object;

            //act
            state.OnEnter();

            //assert
            Assert.That(state.StateState, Is.EqualTo(StateStateEnum.InStack));
        }

        [Test]
        public void OnExit_set_stateState_to_NotInStack()
        {
            //arrange
            var gameManagerCoreMock = new Mock<IGameManagerCore>();
            var gameManagerCore = gameManagerCoreMock.Object;

            var stateMock = new Mock<State>(gameManagerCore);
            stateMock.CallBase = true;

            var state = stateMock.Object;

            //act
            state.OnExit();

            //assert
            Assert.That(state.StateState, Is.EqualTo(StateStateEnum.NotInStack));
        }

        [Test]
        public void OnActivate_set_stateState_to_Activated()
        {
            //arrange
            var gameManagerCoreMock = new Mock<IGameManagerCore>();
            var gameManagerCore = gameManagerCoreMock.Object;

            var stateMock = new Mock<State>(gameManagerCore);
            stateMock.CallBase = true;

            var state = stateMock.Object;

            //act
            state.OnActivate();

            //assert
            Assert.That(state.StateState, Is.EqualTo(StateStateEnum.Activated));
        }

        [Test]
        public void OnDectivate_set_stateState_to_InStack()
        {
            //arrange
            var gameManagerCoreMock = new Mock<IGameManagerCore>();
            var gameManagerCore = gameManagerCoreMock.Object;

            var stateMock = new Mock<State>(gameManagerCore);
            stateMock.CallBase = true;

            var state = stateMock.Object;

            //act
            state.OnDeactivate();

            //assert
            Assert.That(state.StateState, Is.EqualTo(StateStateEnum.InStack));
        }
    }


}