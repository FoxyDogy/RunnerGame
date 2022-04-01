using System;
using _Game.Code.Abstract;
using _Game.Code.Base;
using UnityEngine;

namespace _Game.Code
{
    public class Obstacle : MonoBehaviour, Iinteractable
    {
        public void Interact(Action action = null)
        {
            CharacterController.Instance.CollideObstacle();
        }
    }
}