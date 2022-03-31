using _Game.Code.Base;
using UnityEngine;

namespace _Game.Code.UI
{
    public class InGameUI : MonoBehaviour
    {
        public GameObject content;
        private void OnEnable()
        {
            GameController.Instance.onStartGame += OnStartGame;
            GameController.Instance.onEndGame += EndGame;
        }

        private void OnStartGame()
        {
            content.SetActive(true);
        }

        private void EndGame(bool obj)
        {
            content.SetActive(false);
        }
    }
}