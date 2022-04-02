using System;
using _Game.Code.Base;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Code.UI
{
    public class MainMenuUI : DataBehaviour
    {
        public GameObject content;
        public TextMeshProUGUI levelText;
        public TextMeshProUGUI coinText;

        private void Awake()
        {
            content.SetActive(true);
        }

        private void OnEnable()
        {
            GameController.Instance.onBootGame += RefreshMenu;
            CoinManager.Instance.onUserCoinUpdate += RefreshMenu;
            GameController.Instance.onStartGame += HideMainMenuUI;
        }


        private void RefreshMenu()
        {
            levelText.text = "LEVEL " + (Data.currentUserData.levelNo + 1);
            coinText.text = Data.currentUserData.coinCount.ToString();
        }

        private void Update()
        {
            if (Data.GameState != GameState.Boot)
                return;

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                GameController.Instance.StartGame(); // State Change to Game
            }
        }

        private void HideMainMenuUI()
        {
            content.SetActive(false);
        }
    }
}