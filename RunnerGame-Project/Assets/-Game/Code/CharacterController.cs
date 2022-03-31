using System;
using _Game.Code.Abstract;
using UnityEngine;

namespace _Game.Code
{
    [RequireComponent(typeof(UserInput))]
    public class CharacterController : MonoBehaviour
    {
        private UserInput userInput;
        public float speed = 3;

        private void Awake()
        {
            userInput = GetComponent<UserInput>();
        }

        private void FixedUpdate()
        {
            transform.Translate(userInput.moveFactorX * speed * Time.deltaTime, 0, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Iinteractable interactable))
            {
                interactable.Interact();
                if (interactable is Obstacle)
                {
                    Dead();
                }
            }
        }

        private void Dead()
        {
            
        }
    }
}