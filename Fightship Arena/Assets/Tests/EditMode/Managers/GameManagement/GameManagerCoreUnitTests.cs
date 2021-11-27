using System;
using FightShipArena.Assets.Scripts;
using FightShipArena.Assets.Scripts.Managers.GameManagement;
using FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using UnityEngine;

namespace FightshipArena.Assets.Tests.EditMode.Managers.GameManagement
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

        [Test]
        public void OnAwake_attaches_eventListeners_to_stateStack()
        {
            //arrange
            var stateStackMock = new StateStackMock();

            var parentMock = new Mock<IMyMonoBehaviour>();
            var parent = parentMock.Object;

            var coreMock = new Mock<GameManagerCoreMock>(parent);

            var core = coreMock.Object;
            core.StateStack = stateStackMock;

            var stateMock = new Mock<State>(core);
            var state = stateMock.Object;

            //act
            core.OnAwake();

            stateStackMock.RaisePoppingStateEvent_Caller(state);
            stateStackMock.RaisePushingStateEvent_Caller(state);

            //assert
            coreMock.Protected().Verify("StateStack_PoppingStateEvent", Times.Once(), ItExpr.IsAny<object>(), state);
            coreMock.Protected().Verify("StateStack_PushingStateEvent", Times.Once(), ItExpr.IsAny<object>(), state);
        }

        [Test]
        public void OnStart_calls_PushState()
        {
            //arrange
            var stateStackMock = new StateStackMock();

            var parentMock = new Mock<IMyMonoBehaviour>();
            var parent = parentMock.Object;

            var coreMock = new Mock<GameManagerCoreMock>(parent);

            var core = coreMock.Object;
            core.StateStack = stateStackMock;

            var stateMock = new Mock<State>(core);
            var state = stateMock.Object;

            //act
            core.OnStart();

            //assert
            coreMock.Protected().Verify("PushState", Times.Once(), ItExpr.IsAny<Init>());
        }

        [Test]
        public void OnAwake_subscribes_events_on_StackState()
        {
            //arrange
            var stateStackMock = new Mock<StateStack>();
            stateStackMock.SetupAdd(m => m.PoppingStateEvent += (sender, args) => { });
            stateStackMock.SetupAdd(m => m.PushingStateEvent += (sender, args) => { });

            var stateStack = stateStackMock.Object;

            var gameManagerMock = new Mock<IMyMonoBehaviour>();
            var gameManager = gameManagerMock.Object;

            var core = new GameManagerCoreMock(gameManager);

            core.StateStack = stateStack;

            //act
            core.OnAwake();
            //assert

            stateStackMock.VerifyAdd(m => m.PoppingStateEvent += It.IsAny<EventHandler<State>>(), Times.Once);
            stateStackMock.VerifyAdd(m => m.PushingStateEvent += It.IsAny<EventHandler<State>>(), Times.Once);
        }


        public class GameManagerCoreMock : GameManagerCore
        {
            public StateStack StateStack
            {
                get => _stateStack;
                set => _stateStack = value;
            }

            public GameManagerCoreMock(IMyMonoBehaviour parent) : base(parent) { }
        }

        public class StateStackMock : StateStack
        {
            public void RaisePoppingStateEvent_Caller(State state) => RaisePoppingStateEvent(state);
            public void RaisePushingStateEvent_Caller(State state) => RaisePushingStateEvent(state);
        }
    }
}
