using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YJH
{
    public abstract class BaseState
    {
        protected PlayerYoo player;

        protected BaseState(PlayerYoo player)
        {
            this.player = player;
        }

        public abstract void OnStateEnter();
        public abstract void OnStateUpdate();
        public abstract void OnStateExit();
    }
}
