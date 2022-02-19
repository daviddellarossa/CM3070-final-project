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
        public float ArenaAspect = 1;

        public Vector2 SpawnPointsMargin = Vector2.one;
            
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

        public GameObject SpawnPoints;

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
            var newSize = new Vector3(size.y * ArenaAspect, size.y, 0);

            var halfBorder = BorderLocalScale / 2;

            // Set the corners
            TopLeft.transform.position = new Vector3(-newSize.x + halfBorder.x, newSize.y - halfBorder.y);
            BottomRight.transform.position = new Vector3(newSize.x - halfBorder.x, -newSize.y + halfBorder.y);
            TopRight.transform.position = newSize - halfBorder;
            BottomLeft.transform.position = -newSize + halfBorder;

            // Now set the borders
            Left.transform.position = new Vector3(-newSize.x + halfBorder.x, 0);
            Right.transform.position = new Vector3(newSize.x - halfBorder.x, 0);
            Top.transform.position = new Vector3(0, newSize.y - halfBorder.y);
            Bottom.transform.position = new Vector3(0, -newSize.y + halfBorder.y);

            // Scale the borders
            Top.transform.localScale = new Vector3(newSize.x * 2, BorderLocalScale.y, BorderLocalScale.z);
            Bottom.transform.localScale = new Vector3(newSize.x * 2, BorderLocalScale.y, BorderLocalScale.z);
            Left.transform.localScale = new Vector3(BorderLocalScale.x, newSize.y * 2, BorderLocalScale.z);
            Right.transform.localScale = new Vector3(BorderLocalScale.x, newSize.y * 2, BorderLocalScale.z);

            //Set the Spawn points
            var spTL = SpawnPoints.transform.Find("Spawn TL");
            var spTR = SpawnPoints.transform.Find("Spawn TR");
            var spBL = SpawnPoints.transform.Find("Spawn BL");
            var spBR = SpawnPoints.transform.Find("Spawn BR");

            spTL.position = new Vector3(
                TopLeft.transform.position.x + SpawnPointsMargin.x,
                TopLeft.transform.position.y - SpawnPointsMargin.y, 
                0);
            spTR.position = new Vector3(
                TopRight.transform.position.x - SpawnPointsMargin.x,
                TopRight.transform.position.y - SpawnPointsMargin.y, 
                0);
            spBL.position = new Vector3(
                BottomLeft.transform.position.x + SpawnPointsMargin.x,
                BottomLeft.transform.position.y + SpawnPointsMargin.y, 
                0);
            spBR.position = new Vector3(
                BottomRight.transform.position.x - SpawnPointsMargin.x,
                BottomRight.transform.position.y + SpawnPointsMargin.y, 
                0);

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
