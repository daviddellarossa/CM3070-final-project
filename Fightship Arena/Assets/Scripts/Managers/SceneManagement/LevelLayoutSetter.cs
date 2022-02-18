using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.SceneManagement
{
    public class LevelLayoutSetter : MyMonoBehaviour, IMyMonoBehaviour
    {
        public Vector3 BorderLocalScale;
            
        public RectTransform LeftHudPanel;
        public RectTransform RightHudPanel;

        public Camera MainCamera;

        public GameObject TopLeft;
        public GameObject TopRight;
        public GameObject BottomLeft;
        public GameObject BottomRight;
        public GameObject Top;
        public GameObject Bottom;
        public GameObject Left;
        public GameObject Right;

        private Vector3 previousSize;
        void OnGUI()
        {
            var currentSize = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
            
            if (previousSize == currentSize)
            {
                return;
            }
            SetHudPanels(currentSize);
            SetArenaLayout(currentSize);
        }

        private void SetArenaLayout(Vector3 size)
        {
            var newSize = new Vector3(size.y, size.y, 0);

            var halfBorder = BorderLocalScale / 2;
            TopLeft.transform.position = new Vector3(-newSize.x + halfBorder.x, newSize.y - halfBorder.y);
            BottomRight.transform.position = new Vector3(newSize.x - halfBorder.x, -newSize.y + halfBorder.y);
            TopRight.transform.position = newSize - halfBorder;
            BottomLeft.transform.position = -newSize + halfBorder;

            //TODO: now set the borders
            //TODO: add a form factor

        }

        private void SetHudPanels(Vector3 size)
        {
            var halfBorder = TopLeft.transform.localScale.x / 2;

            var tlCorner =
                MainCamera.WorldToScreenPoint(
                    new Vector3(
                        TopLeft.transform.position.x - halfBorder,
                        TopLeft.transform.position.y,
                        TopLeft.transform.position.z
                    )
                );


            RightHudPanel.sizeDelta = new Vector2(tlCorner.x, 0);
            LeftHudPanel.sizeDelta = new Vector2(tlCorner.x, 0);
        }
    }
}
