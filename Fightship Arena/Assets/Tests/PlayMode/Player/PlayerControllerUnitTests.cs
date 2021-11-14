using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.TestTools;

namespace FightshipArena.Assets.Tests.PlayMode.Player
{
    [TestFixture]
    public class PlayerControllerUnitTests
    {
        //private InputTestFixture input = new InputTestFixture();

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

        //[Test]
        //public void OnMove_assigns_movement_to_Core()
        //{
        //    InputTestFixture input = new InputTestFixture();

        //    //var keyboard = InputSystem.AddDevice<Keyboard>();
        //    var keyboard = InputSystem.GetDevice<Keyboard>();
        //    //InputSystem.RemoveDevice();

        //    var playerActions = new PlayerActionAsset();

        //    var playerGO = new GameObject("Player");
        //    playerGO.AddComponent<PlayerController>();

        //    var playerInput = playerGO.AddComponent<PlayerInput>();
        //    playerInput.actions = playerActions.asset;


        //    playerInput.actions.Enable();

        //    using (StateEvent.From(keyboard, out var eventPtr))
        //    {
        //        ((ButtonControl)keyboard["w"]).WriteValueIntoEvent(1f, eventPtr);
        //        InputSystem.QueueEvent(eventPtr);
        //        InputSystem.Update();
        //    }




        //    //var player = PlayerInput.Instantiate(playerGO, controlScheme: "Keyboard");

        //    //var buttonW = (ButtonControl)keyboard["w"];

        //    //input.Press(buttonW);

        //    //Assert.That(player.devices, Is.EquivalentTo(new InputDevice[] { keyboard }));
        //    //Assert.That(player.currentControlScheme, Is.EqualTo("Keyboard"));
        //}

        //[Test, Ignore()]
        //public void OnMove_assigns_movement_to_Core2()
        //{
        //    InputTestFixture input = new InputTestFixture();
            
        //    //var keyboard = InputSystem.AddDevice<Keyboard>();
        //    var keyboard = InputSystem.GetDevice<Keyboard>();
        //    //InputSystem.RemoveDevice();

        //    var playerActions = new PlayerActionAsset();

        //    var playerGO = new GameObject("Player");
        //    playerGO.AddComponent<PlayerController>();

        //    var playerInput = playerGO.AddComponent<PlayerInput>();
        //    playerInput.actions = playerActions.asset;


        //    playerInput.actions.Enable();

        //    //var player = PlayerInput.Instantiate(playerGO);


        //    //using (StateEvent.From(keyboard, out var eventPtr))
        //    //{
        //    //    ((ButtonControl)keyboard["w"]).WriteValueIntoEvent(1f, eventPtr);
        //    //    InputSystem.QueueEvent(eventPtr);
        //    //    InputSystem.Update();
        //    //}

        //    //yield return null;

            

        //    var buttonW = (ButtonControl)keyboard["j"];

        //    input.Press(buttonW);

        //    Assert.That(playerActions.Player.Fire.triggered, Is.True);

        //    //yield return null;

        //    //Assert.That(player.devices, Is.EquivalentTo(new InputDevice[] { keyboard }));
        //    //Assert.That(player.currentControlScheme, Is.EqualTo("Keyboard"));
        //}
    }
}
