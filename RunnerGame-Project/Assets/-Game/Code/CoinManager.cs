using System;
using _Game.Code.Base;
using _Game.Code.Utils;
using UnityEngine;

namespace _Game.Code
{
    public class CoinManager : DataBehaviour<CoinManager>
    {
        private int userCoinCount;
        private int sessionCoinCount;
        
        public Action<int> onSessionCoinUpdate;
        public Action onUserCoinUpdate;
        public Action onSpendUserCoin;
        public int UserCoinCount
        {
            get => userCoinCount;
            set
            {
                userCoinCount = value;
                Data.currentUserData.coinCount = userCoinCount;
                onUserCoinUpdate?.Invoke();
            } 
        }
        public int SessionCoinCount
        {
            get => sessionCoinCount;
            set
            {
                sessionCoinCount = value;
                onSessionCoinUpdate?.Invoke(sessionCoinCount);
            }
        }
        private void OnEnable()
        {
            GameController.Instance.onBootGame += GetUserCoin;
            GameController.Instance.onEndGame += SetUserCoin;
        }
        private void GetUserCoin()
        {
            UserCoinCount = Data.currentUserData.coinCount;
        }

        private void SetUserCoin(bool state)
        {
            if (state)
            {
                UserCoinCount += sessionCoinCount;
            }
        }
        public void AddCoin(int count)
        {
            SessionCoinCount += count;
        }

        public bool SpendCoin(int cost)
        {
            if (UserCoinCount>=cost)
            {
                UserCoinCount -= cost;
                onSpendUserCoin?.Invoke();
                GameController.Instance.SaveUserData();
                return true;
            }

            return false;
        }

        public bool CompareCost(int cost)
        {
            return SessionCoinCount >= cost;
        }
    }
}