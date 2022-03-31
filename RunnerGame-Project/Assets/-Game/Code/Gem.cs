using System;
using _Game.Code.Abstract;
using UnityEngine;

namespace _Game.Code
{
    public class Gem : MonoBehaviour, Iinteractable
    {
        public void Interact(Action action = null)
        {
            CoinManager.Instance.AddCoin(1);
            Destroy(gameObject);
        }
    }
}