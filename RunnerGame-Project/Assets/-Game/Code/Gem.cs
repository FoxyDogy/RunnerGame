using System;
using _Game.Code.Abstract;
using _Game.Code.Base;

namespace _Game.Code
{
    public class Gem : DataBehaviour, Iinteractable
    {
        public void Interact(Action action = null)
        {
            var gemValuePerPiece = Data.GetGemValue(Data.currentUserData.gemUpgradeLevel);
            CoinManager.Instance.AddCoin(gemValuePerPiece);
            Destroy(gameObject);
        }
    }
}