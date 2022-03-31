using System;
using _Game.Code.Base;
using UnityEngine;

namespace _Game.Code
{
    public class RoadController : MonoBehaviour
    {
        public float speed = 5; // TODO: data config

        private void FixedUpdate()
        {
            if (GameController.Instance.GameState == GameState.Game)
            {
                transform.Translate(0,0,-speed*Time.deltaTime);
            }
        }
    }
}