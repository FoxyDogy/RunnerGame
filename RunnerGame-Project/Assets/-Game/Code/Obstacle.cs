using System;
using _Game.Code.Abstract;
using _Game.Code.Base;
using UnityEngine;

namespace _Game.Code
{
    [RequireComponent(typeof(Collider))]
    public class Obstacle : MonoBehaviour, Iinteractable
    {
        private Collider collider;

        private void Awake()
        {
            collider = GetComponent<Collider>();
        }

        public void Interact(Action action = null)
        {
            CharacterController.Instance.HitTheObstacle();
            collider.enabled = false;
        }
    }
}