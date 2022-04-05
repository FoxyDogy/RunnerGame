using _Game.Code.Base;
using _Game.Code.Utils;
using TMPro;
using UnityEngine;

namespace _Game.Code.UI
{
    public class InGameUI : DataBehaviour
    {
        public GameObject content;
        public TextMeshProUGUI coinText;
        public TextMeshProUGUI levelText;
        private bool endlessMode;

        private void Awake()
        {
            content.SetActive(false);
            coinText.text = "0";
            endlessMode = PlayerPrefsX.GetBool("endlessMode", false);
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
            if (!endlessMode)
                levelText.text = "LEVEL " + (Data.currentUserData.levelNo + 1);
            else
                levelText.text = "ENDLESS";
        }

        private void HideInGameUI(bool obj)
        {
            content.SetActive(false);
        }
    }
}