using System;
using _Game.Code.Base;
using TMPro;
using UnityEngine;

namespace _Game.Code.UI
{
    public class MainMenuUI : DataBehaviour
    {
        public GameObject content;
        public TextMeshProUGUI levelText;
        private void Awake()
        {
            content.SetActive(true);
        }

        private void OnEnable()
        {
            GameController.Instance.onBootGame += BootGame;
            GameController.Instance.onStartGame += OnStartGame;
        }

        private void BootGame(UserData userData)
        {
            levelText.text ="LEVEL " + (userData.levelNo + 1);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && Data.GameState == GameState.Boot)
            {
                GameController.Instance.StartGame(); // State Change to Game
            }
        }
        private void OnStartGame()
        {
            content.SetActive(false);
        }
    }
}