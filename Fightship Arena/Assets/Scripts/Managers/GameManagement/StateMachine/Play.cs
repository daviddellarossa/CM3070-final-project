﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class Play : State
    {
        public Play(GameManager gameManager) : base(gameManager)
        {
            
        }

        public override event EventHandler<State> ReplaceStateRequestEvent;
        public override event EventHandler<State> PushStateRequestEvent;
    }
}