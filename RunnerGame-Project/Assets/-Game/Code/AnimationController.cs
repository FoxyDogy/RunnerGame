using System;
using _Game.Code.Base;
using Foxy.Utils;
using UnityEngine;

namespace _Game.Code
{
    public class AnimationController : MonoBehaviour
    {
        public Animator animator;
        
        private void Awake()
        {
            if (animator == null)
            {
                animator = GetComponentInChildren<Animator>();
            }
            animator.SetTrigger("idle");
        }

        private void OnEnable()
        {
            GameController.Instance.onStartGame += OnStartGame;
            CharacterController.Instance.onCollideObstacle += Hit;
        }

        private void Hit()
        {
            animator.SetTrigger("hit");
        }

        private void OnStartGame()
        {
            animator.SetTrigger("run");
        }
    }
}