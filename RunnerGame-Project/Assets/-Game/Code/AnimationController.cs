using System.Collections;
using _Game.Code.Base;
using UnityEngine;

namespace _Game.Code
{
    public class AnimationController : MonoBehaviour
    {
        public Animator animator;

        private void Awake()
        {
            if (animator == null) animator = GetComponentInChildren<Animator>();
            animator.SetTrigger("idle");
        }

        private void OnEnable()
        {
            GameController.Instance.onStartGame += Run;
            GameController.Instance.onEndGame += delegate(bool b)
            {
                StartCoroutine(EndGame(b));
            };
            CharacterController.Instance.onCollideObstacle += Hit;
        }

        private IEnumerator EndGame(bool obj)
        {
            animator.SetTrigger("idle");
            yield return new WaitForSeconds(1);
            if (obj)
                animator.SetTrigger("win");
            else
                animator.SetTrigger("dead");
        }

        private void Hit()
        {
            animator.SetTrigger("hit");
        }

        private void Run()
        {
            animator.SetTrigger("run");
        }
    }
}