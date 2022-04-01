using System;
using _Game.Code.Base;
using UnityEngine;

namespace _Game.Code
{
    public class RoadController : DataBehaviour<RoadController>
    {
        private void FixedUpdate()
        {
            if (Data.GameState == GameState.Game)
            {
                transform.Translate(0, 0, -Data.config.forwardMovementSpeed * Time.deltaTime);
            }
        }
        public void Play()
        {
            enabled = true;
        }
        public void Stop()
        {
            enabled = false;
        }
    }
}