using System;
using _Game.Code.Base;
using UnityEngine;

namespace _Game.Code.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        public GameObject content;

        private void OnEnable()
        {
            GameController.Instance.onStartGame += OnStartGame;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && GameController.Instance.GameState == GameState.Boot)
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