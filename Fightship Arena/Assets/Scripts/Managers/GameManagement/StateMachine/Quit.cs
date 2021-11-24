using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement.StateMachine
{
    public class Quit : State
    {
        public Quit(GameManager gameManager) : base(gameManager) { }

        public override event EventHandler<State> ReplaceStateRequestEvent;
        public override event EventHandler<State> PushStateRequestEvent;

        public override void OnActivate()
        {
            base.OnActivate();
            Application.Quit();
        }

    }
}
