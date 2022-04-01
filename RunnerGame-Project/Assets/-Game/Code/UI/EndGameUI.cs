using System;
using _Game.Code.Base;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Code.UI
{
    public class EndGameUI : MonoBehaviour
    {
        public GameObject winGroup;
        public GameObject failGroup;
        public Button nextLevelButton;
        public Button retryLevelButton;
        private void Awake()
        {
            ButtonsInit();
            winGroup.SetActive(false);
            failGroup.SetActive(false);
        }

        private void OnEnable()
        {
            GameController.Instance.onEndGame += EndGame;
        }

        private void ButtonsInit()
        {
            nextLevelButton.onClick.RemoveAllListeners();
            retryLevelButton.onClick.RemoveAllListeners();
            
            nextLevelButton.onClick.AddListener(NextLevelClick);
            retryLevelButton.onClick.AddListener(RetryLevelClick);
        }
        private void EndGame(bool obj)
        {
            winGroup.SetActive(obj);
            failGroup.SetActive(!obj);
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