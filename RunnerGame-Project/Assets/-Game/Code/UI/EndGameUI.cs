using System.Collections;
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
        public TextMeshProUGUI youEarnLostText;
        public CanvasGroup sessionCoinsParent;
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
            if (obj || Data.currentUserData.endlessMode)
            {
                StartCoroutine( CoinAnimation());
                youEarnLostText.text = "YOU EARN";
            }
            else
            {
                youEarnLostText.text = "YOU LOST";
            }
             
        }

        private IEnumerator CoinAnimation()
        {
            yield return new WaitForSeconds(1);
            sessionCoinText.GetComponent<NumberCounter>().SetNumber(0,0.5f);
            var userCoinTargetNumber = CoinManager.Instance.SessionCoinCount + CoinManager.Instance.UserCoinCount;
            userCoinText.GetComponent<NumberCounter>().SetNumber(userCoinTargetNumber,0.5f);
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(FadeSessionCoins(0, 1));

        }

        private IEnumerator FadeSessionCoins(float end, float duration)
        {
            float counter = 0;
            while (counter<duration)
            {
                counter += Time.fixedDeltaTime;
                sessionCoinsParent.alpha -= Mathf.Lerp(counter, end, counter / duration);
                yield return null;
            }
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