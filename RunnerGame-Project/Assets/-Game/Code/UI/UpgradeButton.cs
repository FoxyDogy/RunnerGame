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
        public int level;
        public int cost;
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
            GameController.Instance.onBootGame += Init;
        }

        public void Init()
        {
            switch (upgradeType)
            {
                case UpgradeType.Life:
                    level = Data.currentUserData.lifeUpgradeLevel;
                    cost = Data.GetCostGemValue(level);
                    break;
                case UpgradeType.GemValue:
                    level = Data.currentUserData.gemUpgradeLevel;
                    cost = Data.GetCostGemValue(level);
                    break;
            }
            levelText.text = "LEVEL " + (level + 1);
            costText.text = cost.ToString();
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
            }
        }
    }
}