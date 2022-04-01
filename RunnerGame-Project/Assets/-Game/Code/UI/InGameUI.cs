using System;
using _Game.Code.Base;
using TMPro;
using UnityEngine;

namespace _Game.Code.UI
{
    public class InGameUI : DataBehaviour
    {
        public GameObject content;
        public TextMeshProUGUI levelText;
        private void Awake()
        {
            content.SetActive(false);
        }

        private void OnEnable()
        {
            GameController.Instance.onStartGame += OnStartGame;
            GameController.Instance.onEndGame += EndGame;
        }

        private void OnStartGame()
        {
            content.SetActive(true);
            levelText.text ="LEVEL " + (Data.currentUserData.levelNo + 1);
        }

        private void EndGame(bool obj)
        {
            content.SetActive(false);
        }
    }
}