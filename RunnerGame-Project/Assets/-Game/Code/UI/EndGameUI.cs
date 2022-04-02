using _Game.Code.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Code.UI
{
    public class EndGameUI : DataBehaviour
    {
        public TextMeshProUGUI sessionCoinText;
        public TextMeshProUGUI userCoinText;
        public GameObject content;
        public GameObject winGroup;
        public GameObject failGroup;
        public Button nextLevelButton;
        public Button retryLevelButton;

        private void Awake()
        {
            ButtonsInit();
            content.SetActive(false);
            winGroup.SetActive(false);
            failGroup.SetActive(false);
        }

        private void OnEnable()
        {
            GameController.Instance.onEndGame += ShowEndGameUI;
        }

        private void ButtonsInit()
        {
            nextLevelButton.onClick.RemoveAllListeners();
            retryLevelButton.onClick.RemoveAllListeners();

            nextLevelButton.onClick.AddListener(NextLevelClick);
            retryLevelButton.onClick.AddListener(RetryLevelClick);
        }

        private void ShowEndGameUI(bool obj)
        {
            sessionCoinText.text = CoinManager.Instance.SessionCoinCount.ToString();
            userCoinText.text = CoinManager.Instance.UserCoinCount.ToString();

            content.SetActive(true);
            winGroup.SetActive(obj);
            failGroup.SetActive(!obj);
            if (obj) CoinAnimation();
        }

        public void CoinAnimation()
        {
            sessionCoinText.text = CoinManager.Instance.SessionCoinCount.ToString();
            userCoinText.text = CoinManager.Instance.UserCoinCount.ToString();
        }

        private void NextLevelClick()
        {
            GameController.Instance.NextLevel();
        }

        private void RetryLevelClick()
        {
            GameController.Instance.RestartGame();
        }
    }
}