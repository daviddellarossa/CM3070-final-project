using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightShipArena.Assets.Scripts.Player;
using Moq;
using NUnit.Framework;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.TestTools;

namespace FightshipArena.Assets.Tests.EditMode.Player
{
    public class PlayerControllerUnitTests
    {
        private InputTestFixture input = new InputTestFixture();

        [Test]
        public void OnMove_assigns_movement_to_Core()
        {
            var keyboard = InputSystem.AddDevice<Keyboard>();


            //var iam = AssetDatabase.LoadAssetAtPath("Assets/Input/PlayerActions", typeof(InputActionMap));
            var inputActionsContent = File.ReadAllText(@".\Assets\Input\PlayerActions.inputactions");

            var playerGO = new GameObject("Player");
            playerGO.AddComponent<PlayerController>();

            //prefab.SetActive(false);
            var prefabPlayerInput = playerGO.AddComponent<PlayerInput>();
            prefabPlayerInput.actions = InputActionAsset.FromJson(inputActionsContent);



            using (StateEvent.From(keyboard, out var eventPtr))
            {
                ((ButtonControl)keyboard["w"]).WriteValueIntoEvent(1f, eventPtr);
                InputSystem.QueueEvent(eventPtr);
                InputSystem.Update();
            }

            
            var player = PlayerInput.Instantiate(playerGO, controlScheme: "Keyboard");

            var buttonW = (ButtonControl) keyboard["w"];

            input.Press(buttonW);

            Assert.That(player.devices, Is.EquivalentTo(new InputDevice[] { keyboard }));
            Assert.That(player.currentControlScheme, Is.EqualTo("Keyboard"));
        }

    }

}
