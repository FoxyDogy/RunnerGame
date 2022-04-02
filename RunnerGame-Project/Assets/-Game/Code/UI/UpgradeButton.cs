using System;
using _Game.Code.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Code.UI
{
    public enum UpgradeType
    {
        Life,
        GemValue
    }

    [RequireComponent(typeof(Button))]
    public class UpgradeButton : DataBehaviour
    {
        private Button button;
        private int level;
        private int maxLevel;
        private int cost;
        public UpgradeType upgradeType;
        public TextMeshProUGUI levelText;
        public TextMeshProUGUI costText;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(Click);
        }

        private void OnEnable()
        {
            GameController.Instance.onBootGameCompleted += Init;
        }

        private void Init()
        {
            //TODO: Buralari biraz daha generic hale getir
            switch (upgradeType)
            {
                case UpgradeType.Life:
                    level = Data.currentUserData.lifeUpgradeLevel;
                    maxLevel = Data.config.upgradeData.lifeUpgrades.Length - 1;
                    cost = Data.GetCostLifeCount(level);
                    break;
                case UpgradeType.GemValue:
                    level = Data.currentUserData.gemUpgradeLevel;
                    maxLevel = Data.config.upgradeData.gemUpgradeCosts.Length - 1;
                    cost = Data.GetCostGemValue(level);
                    break;
            }

            var levelString = "LEVEL " + (level + 1);
            var costString = cost.ToString();
            if (level == maxLevel)
            {
                levelString = "MAX LEVEL";
                costString = string.Empty;
                button.interactable = false;
            }

            levelText.text = levelString;
            costText.text = costString;
        }

        private void Click()
        {
            if (CoinManager.Instance.SpendCoin(cost))
            {
                switch (upgradeType)
                {
                    case UpgradeType.Life:
                        Data.currentUserData.lifeUpgradeLevel += 1;
                        break;
                    case UpgradeType.GemValue:
                        Data.currentUserData.gemUpgradeLevel += 1;
                        break;
                }

                GameController.Instance.SaveUserData();
                Init();
            }
        }
    }
}