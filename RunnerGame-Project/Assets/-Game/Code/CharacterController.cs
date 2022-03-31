using System;
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
    }
}