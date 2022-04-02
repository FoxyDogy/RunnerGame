using System;
using _Game.Code.Abstract;
using _Game.Code.Base;
using UnityEngine;

namespace _Game.Code
{
    public class Gem : DataBehaviour, Iinteractable
    {
        public void Interact(Action action = null)
        {
            CoinManager.Instance.AddCoin(Data.config.gemValuePerPiece);
            Destroy(gameObject);
        }
    }
}