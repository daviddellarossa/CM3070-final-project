using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FightShipArena
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public class InputScalerProcessor : InputProcessor<float>
    {
#if UNITY_EDITOR
        static InputScalerProcessor()
        {
            Initialize();
        }
#endif

        [RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            InputSystem.RegisterProcessor<InputScalerProcessor>();
        }

        public float ScaleFactor;

        public override float Process(float value, InputControl control)
        {
            return value * ScaleFactor;
        }
    }
}
