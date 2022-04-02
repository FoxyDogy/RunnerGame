using System;
using System.Collections;
using _Game.Code.Abstract;
using _Game.Code.Base;
using _Game.Code.Utils;
using Foxy.Utils;
using UnityEngine;

namespace _Game.Code
{
    [RequireComponent(typeof(UserInput))]
    public class CharacterController : DataBehaviour<CharacterController>
    {
        private int lifeCount;
        public int LifeCount
        {
            get
            {
                return lifeCount;
            }
            private set
            {
                lifeCount = value;
                onLifeUpdate?.Invoke(lifeCount);
            }
        }

        private UserInput userInput;
        public Action onCollideObstacle;
        public Action<int> onLifeUpdate;
        private void Awake()
        {
            userInput = GetComponent<UserInput>();
        }

        private void OnEnable()
        {
            GameController.Instance.onBootGameCompleted += GetCharacterValues;
        }

        private void GetCharacterValues()
        {
            LifeCount = Data.GetLifeCount(Data.currentUserData.lifeUpgradeLevel);
        }

        private void FixedUpdate()
        {
            Movement();
        }
        
        private void Movement()
        {
            if (Data.GameState == GameState.Game)
            {
                transform.Translate(userInput.moveFactorX * Data.config.inputSensitivity * Time.deltaTime, 0,0);
                transform.position = transform.position.Clamp(Data.config.movementBoundaries);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Iinteractable interactable))
            {
                interactable.Interact();
            }
        }

        private IEnumerator StopMovement()
        {
            //TOD: Dependencyi kaldir
            RoadController.Instance.Stop();
            yield return new WaitForSeconds(1);
            RoadController.Instance.Play();
        }
        public void HitTheObstacle()
        {
            LifeCount--;
            onCollideObstacle?.Invoke();
            StartCoroutine(StopMovement());
            if (lifeCount<=0)
            {
                GameController.Instance.EndGame(false);
            }
        }
    }
}