using System;
using _Game.Code.Base;

namespace _Game.Code
{
    public class CoinManager : DataBehaviour<CoinManager>
    {
        public Action<int> onSessionCoinUpdate;
        public Action onSpendUserCoin;
        public Action onUserCoinUpdate;
        private int sessionCoinCount;
        private int userCoinCount;

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
            if (state) UserCoinCount += sessionCoinCount;
        }

        public void AddCoin(int count)
        {
            SessionCoinCount += count;
        }

        public bool SpendCoin(int cost)
        {
            if (UserCoinCount >= cost)
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