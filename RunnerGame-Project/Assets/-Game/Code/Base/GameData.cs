using System;
using Foxy.Utils;
using UnityEngine;

namespace _Game.Code.Base

{
    [CreateAssetMenu(fileName = "GameData", menuName = "Foxy/GameData", order = 0)]
    public class GameData : ScriptableObject
    {
        public Config config;
        public UserData currentUserData;
        public GameState GameState { get; set; }


        public int GetGemValue(int level)
        {
            return config.upgradeData.gemUpgrades[level];
        }

        public int GetLifeCount(int level)
        {
            return config.upgradeData.lifeUpgrades[level];
        }

        public int GetCostGemValue(int level)
        {
            return config.upgradeData.gemUpgradeCosts[level];
        }

        public int GetCostLifeCount(int level)
        {
            return config.upgradeData.lifeUpgradeCosts[level];
        }
    }

    [Serializable]
    public class Config
    {
        public float inputSensitivity = 3;
        public float forwardMovementSpeed = 5;
        public Boundaries movementBoundaries;
        public UpgradeData upgradeData;
    }

    [Serializable]
    public struct UpgradeData
    {
        public int[] gemUpgradeCosts;
        public int[] lifeUpgradeCosts;
        public int[] gemUpgrades;
        public int[] lifeUpgrades;
    }

    [Serializable]
    public struct UserData
    {
        public int levelNo;
        public int coinCount;
        public int gemUpgradeLevel;
        public int lifeUpgradeLevel;

        public static UserData Defaults()
        {
            var defaultData = new UserData();
            defaultData.levelNo = 0;
            defaultData.coinCount = 10;
            defaultData.gemUpgradeLevel = 0;
            defaultData.lifeUpgradeLevel = 0;

            return defaultData;
        }
    }
}