using _Game.Code.Base;
using UnityEngine;

namespace _Game.Code.UI
{
    public class EndGameUI : MonoBehaviour
    {
        public GameObject content;
        private void OnEnable()
        {
            
            GameController.Instance.onEndGame += EndGame;
        }
        
        private void EndGame(bool obj)
        {
            content.SetActive(true);
        }
    }
}