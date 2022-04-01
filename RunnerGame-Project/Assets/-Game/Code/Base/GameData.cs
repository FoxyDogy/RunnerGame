using System;
using Foxy.Utils;
using UnityEngine;

namespace _Game.Code.Base

{
    [CreateAssetMenu(fileName = "GameData", menuName = "Foxy/GameData", order = 0)]
    public class GameData : ScriptableObject
    {
        public GameState GameState { get; set; } // 
        public Config config;
        public UserData currentUserData;

    }

    [Serializable]
    public class Config
    {
        public float inputSensitivity=3;
        public float forwardMovementSpeed=5;
        public Boundaries boundaries;
    }
}