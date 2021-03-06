using System;
using _Game.Code.Abstract;
using _Game.Code.Base;
using UnityEngine;

namespace _Game.Code
{
    public class Finish : MonoBehaviour, Iinteractable
    {
        public void Interact(Action action = null)
        {
            GameController.Instance.EndGame(true);
        }
    }
}