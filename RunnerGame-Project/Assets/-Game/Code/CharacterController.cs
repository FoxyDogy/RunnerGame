using System;
using System.Collections;
using _Game.Code.Abstract;
using _Game.Code.Base;
using _Game.Code.Utils;
using Foxy.Utils;
using UnityEngine;

namespace _Game.Code
{
    public enum CharacterState
    {
        Stop,
        Playing
    }

    [RequireComponent(typeof(UserInput))]
    public class CharacterController : DataBehaviour<CharacterController>
    {
        private UserInput userInput;
        private float speed;
        public Action onCollideObstacle;
        public Action onLossLife;
        private void Awake()
        {
            userInput = GetComponent<UserInput>();
            speed = Data.config.forwardMovementSpeed;
        }
        private void FixedUpdate()
        {
            if (Data.GameState == GameState.Game)
            {
                transform.Translate(userInput.moveFactorX * Data.config.inputSensitivity * Time.deltaTime, 0,0);
                transform.position = transform.position.Clamp(Data.config.boundaries);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Iinteractable interactable))
            {
                interactable.Interact();
            }
        }

        public void CollideObstacle()
        {
            StartCoroutine(StopMovement());
            onCollideObstacle?.Invoke();
            onLossLife?.Invoke();
        }

        private IEnumerator StopMovement()
        {
            //TODO: Dependencyi kaldir
            RoadController.Instance.Stop();
            yield return new WaitForSeconds(1);
            RoadController.Instance.Play();
        }
    }
}