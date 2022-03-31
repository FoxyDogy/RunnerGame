using System;
using _Game.Code.Utils;
using UnityEngine;

namespace _Game.Code
{
    public class CoinManager : Singleton<CoinManager>
    {
        public int coinCount;
        public Action onSpendCoin;
        public Action onAddCoin;
        public void AddCoin(int count)
        {
            coinCount += count;
            onAddCoin?.Invoke();
        }

        public void SpendCoin(int coin)
        {
            coinCount -= coin;
            onSpendCoin?.Invoke();
        }
    }
}