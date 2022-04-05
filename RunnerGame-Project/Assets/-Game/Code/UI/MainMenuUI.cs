using _Game.Code.Base;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Game.Code.UI
{
    public class MainMenuUI : DataBehaviour
    {
        public GameObject content;
        public TextMeshProUGUI levelText;
        public TextMeshProUGUI coinText;
        public Button endlessButton;

        private void Awake()
        {
            content.SetActive(true);
        }
        private void OnEnable()
        {
            GameController.Instance.onBootGameCompleted += RefreshMenu;
            GameController.Instance.onStartGame += HideMainMenuUI;
            CoinManager.Instance.onUserCoinUpdate += RefreshMenu;
            endlessButton.onClick.AddListener(EndlessButtonClick);
        }

 
        private void Update()
        {
            if (Data.GameState != GameState.Boot)
                return;

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                GameController.Instance.StartGame(); // State Change to Game
        }
        private void EndlessButtonClick()
        {
            var beforeState = Data.currentUserData.endlessMode;
            Data.currentUserData.endlessMode = !beforeState;
            GameController.Instance.SaveUserData();
            SceneManager.LoadScene(0);

        }
        private void RefreshMenu()
        {
            if (!Data.currentUserData.endlessMode)
            {
                levelText.text = "LEVEL " + (Data.currentUserData.levelNo + 1);
            }
            else
            {
                levelText.text = "ENDLESS";
            }
            coinText.text = Data.currentUserData.coinCount.ToString();
        }

        private void HideMainMenuUI()
        {
            content.SetActive(false);
        }
    }
}