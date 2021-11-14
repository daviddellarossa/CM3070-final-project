using FightShipArena;
using FightShipArena.Assets.Scripts.Player;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace FightshipArena.Assets.Tests.PlayMode.Input
{
    [TestFixture]
    public class BindingsUnitTests
    {

        bool sceneLoaded;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("Test Input", LoadSceneMode.Single);
        }


        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            sceneLoaded = true;
        }

        private Keyboard ResetAndReturnKeyboard()
        {
            var keyboard = InputSystem.GetDevice<Keyboard>();

            InputSystem.RemoveDevice(keyboard);

            return InputSystem.AddDevice<Keyboard>();
        }

        [UnityTest]
        public IEnumerator Key_W_assigns_movement_to_Core()
        {
            //arrange
            yield return new WaitWhile(() => sceneLoaded == false);

            InputTestFixture input = new InputTestFixture();

            var keyboard  = ResetAndReturnKeyboard();

            var player = GameObject.FindGameObjectWithTag("Player");

            var playerController = player.GetComponent<PlayerController>();

            var playerInput = player.GetComponent<PlayerInput>();

            //WARNING: This part is subject to break if the Processor structure attached to the action changes.
            var playerActionAsset = new PlayerActionAsset();

            var processor = playerActionAsset.Player.Move.processors;

            var regex = @"InputScaler\(ScaleFactor=?([0-9]+\.?[0-9]*|\.[0-9]+)\)";
            var match = Regex.Match(processor, regex);

            var value = float.Parse(match.Groups[1].Value);
            //-------------------------------------------------------------------------------

            Vector3 firstValue = new Vector3(0f, value, 0f);
            var secondValue = Vector3.zero;

            var playerControllerCoreMock = new Mock<IPlayerControllerCore>();

            playerControllerCoreMock.SetupProperty(x => x.Movement, firstValue);
            playerControllerCoreMock.SetupProperty(x => x.Movement, Vector3.zero);


            var playerControllerCore = playerControllerCoreMock.Object;
            playerController.Core = playerControllerCore;

            //act
            input.Press((ButtonControl)keyboard["w"]);

            yield return null;

            //assert
            playerControllerCoreMock.VerifyAll();

        }

        [UnityTest]
        public IEnumerator Key_A_assigns_movement_to_Core()
        {
            //arrange
            yield return new WaitWhile(() => sceneLoaded == false);

            InputTestFixture input = new InputTestFixture();

            var keyboard  = ResetAndReturnKeyboard();

            var player = GameObject.FindGameObjectWithTag("Player");

            var playerController = player.GetComponent<PlayerController>();

            var playerInput = player.GetComponent<PlayerInput>();


            //WARNING: This part is subject to break if the Processor structure attached to the action changes.
            var playerActionAsset = new PlayerActionAsset();

            var processor = playerActionAsset.Player.Move.processors;

            var regex = @"InputScaler\(ScaleFactor=?([0-9]+\.?[0-9]*|\.[0-9]+)\)";
            var match = Regex.Match(processor, regex);

            var value = float.Parse(match.Groups[1].Value);
            //-------------------------------------------------------------------------------

            Vector3 firstValue = new Vector3(-value, 0f, 0f);
            var secondValue = Vector3.zero;

            var playerControllerCoreMock = new Mock<IPlayerControllerCore>();

            playerControllerCoreMock.SetupProperty(x => x.Movement, firstValue);
            playerControllerCoreMock.SetupProperty(x => x.Movement, Vector3.zero);


            var playerControllerCore = playerControllerCoreMock.Object;
            playerController.Core = playerControllerCore;

            //act
            input.Press((ButtonControl)keyboard["a"]);

            yield return null;

            //assert
            playerControllerCoreMock.VerifyAll();

        }

        [UnityTest]
        public IEnumerator Key_S_assigns_movement_to_Core()
        {
            //arrange
            yield return new WaitWhile(() => sceneLoaded == false);

            InputTestFixture input = new InputTestFixture();

            var keyboard = ResetAndReturnKeyboard();

            var player = GameObject.FindGameObjectWithTag("Player");

            var playerController = player.GetComponent<PlayerController>();

            var playerInput = player.GetComponent<PlayerInput>();


            //WARNING: This part is subject to break if the Processor structure attached to the action changes.
            var playerActionAsset = new PlayerActionAsset();

            var processor = playerActionAsset.Player.Move.processors;

            var regex = @"InputScaler\(ScaleFactor=?([0-9]+\.?[0-9]*|\.[0-9]+)\)";
            var match = Regex.Match(processor, regex);

            var value = float.Parse(match.Groups[1].Value);
            //-------------------------------------------------------------------------------

            Vector3 firstValue = new Vector3(0f, -value, 0f);
            var secondValue = Vector3.zero;

            var playerControllerCoreMock = new Mock<IPlayerControllerCore>();

            playerControllerCoreMock.SetupProperty(x => x.Movement, firstValue);
            playerControllerCoreMock.SetupProperty(x => x.Movement, Vector3.zero);


            var playerControllerCore = playerControllerCoreMock.Object;
            playerController.Core = playerControllerCore;

            //act
            input.Press((ButtonControl)keyboard["s"]);

            yield return null;

            //assert
            playerControllerCoreMock.VerifyAll();

        }

        [UnityTest]
        public IEnumerator Key_D_assigns_movement_to_Core()
        {
            //arrange
            yield return new WaitWhile(() => sceneLoaded == false);

            InputTestFixture input = new InputTestFixture();

            var keyboard = ResetAndReturnKeyboard();

            var player = GameObject.FindGameObjectWithTag("Player");

            var playerController = player.GetComponent<PlayerController>();

            var playerInput = player.GetComponent<PlayerInput>();


            //WARNING: This part is subject to break if the Processor structure attached to the action changes.
            var playerActionAsset = new PlayerActionAsset();

            var processor = playerActionAsset.Player.Move.processors;

            var regex = @"InputScaler\(ScaleFactor=?([0-9]+\.?[0-9]*|\.[0-9]+)\)";
            var match = Regex.Match(processor, regex);

            var value = float.Parse(match.Groups[1].Value);
            //-------------------------------------------------------------------------------

            Vector3 firstValue = new Vector3(-value, 0f, 0f);
            var secondValue = Vector3.zero;

            var playerControllerCoreMock = new Mock<IPlayerControllerCore>();

            playerControllerCoreMock.SetupProperty(x => x.Movement, firstValue);
            playerControllerCoreMock.SetupProperty(x => x.Movement, Vector3.zero);


            var playerControllerCore = playerControllerCoreMock.Object;
            playerController.Core = playerControllerCore;

            //act
            input.Press((ButtonControl)keyboard["d"]);

            yield return null;

            //assert
            playerControllerCoreMock.VerifyAll();
        }

    }
}
