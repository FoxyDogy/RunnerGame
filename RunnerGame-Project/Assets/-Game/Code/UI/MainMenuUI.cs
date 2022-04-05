using System.Collections;
using _Game.Code.Base;
using _Game.Code.Utils;
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
        private bool endlessMode;

        private void Awake()
        {
            content.SetActive(true);
            endlessMode = PlayerPrefsX.GetBool("endlessMode", false);
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

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && content.activeSelf)
                GameController.Instance.StartGame(); // State Change to Game
        }

        private void EndlessButtonClick()
        {
            PlayerPrefsX.SetBool("endlessMode", !endlessMode);
            PlayerPrefs.Save();
            SceneManager.LoadScene(0);
        }

        private void RefreshMenu()
        {
        
            if (!endlessMode)
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