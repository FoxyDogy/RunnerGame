using System;
using _Game.Code.Base;
using TMPro;
using UnityEngine;

namespace _Game.Code.UI
{
    public class InGameUI : DataBehaviour
    {
        public GameObject content;
        public TextMeshProUGUI coinText;
        public TextMeshProUGUI levelText;

        private void Awake()
        {
            content.SetActive(false);
            coinText.text = "0";
        }

        private void OnEnable()
        {
            GameController.Instance.onStartGame += ShowInGameUI;
            GameController.Instance.onEndGame += HideInGameUI;
            CoinManager.Instance.onSessionCoinUpdate += CoinCountUpdate;
        }

        private void CoinCountUpdate(int currentCoinCount)
        {
            coinText.text = currentCoinCount.ToString();
        }

        private void ShowInGameUI()
        {
            content.SetActive(true);
            levelText.text = "LEVEL " + (Data.currentUserData.levelNo + 1);
        }

        private void HideInGameUI(bool obj)
        {
            content.SetActive(false);
        }
    }
}