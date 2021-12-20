﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Weapons
{
    public abstract class BulletBase : MyMonoBehaviour
    {
        public BulletSettings InitSettings;
        public bool IsDestroyed = false;

        void Awake()
        {
            if (InitSettings == null)
            {
                throw new NullReferenceException("BulletSetting cannot be null");
            }
        }

    }
}