using System;
using _Game.Code.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Code.Base
{
    public enum GameState
    {
        Boot,
        Game,
        Win,
        Fail
    }

    public class GameController : DataBehaviour<GameController>
    {
        private bool endGame;
        public event Action<UserData> onBootGame;
        public event Action onBootGameCompleted;
        public event Action onStartGame;
        public event Action<bool> onEndGame;
        private void Start()
        {
            Application.targetFrameRate = 165;
                Data.GameState = GameState.Boot;
            BootGame();
        }
        private void BootGame()
        {
            var userData = LoadUserData();
            onBootGame?.Invoke(userData);
        }
        public void BootGameCompleted()
        {
            onBootGameCompleted?.Invoke();
        }

        public void StartGame()
        {
            Data.GameState= GameState.Game;
            onStartGame?.Invoke();
        }
        public void EndGame(bool state)
        {
            if (endGame) return;

            endGame = true;
            if (state)
                Data.GameState = GameState.Win;
            else
                Data.GameState = GameState.Fail;
            onEndGame?.Invoke(state);
        }

        public void NextLevel()
        {
            Data.currentUserData.levelNo++;
            SaveUserData();
            SceneManager.LoadScene(0);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
        
        private void SaveUserData()
        {
            var json = JsonUtility.ToJson(Data.currentUserData);
            PlayerPrefs.SetString("UserData",json);
        }
        private UserData LoadUserData()
        {
            if (!PlayerPrefs.HasKey("UserData"))
            {
                Data.currentUserData = UserData.Defaults();
                var jsonData = JsonUtility.ToJson(Data.currentUserData);
                PlayerPrefs.SetString("UserData", jsonData);
            }

            var userDataJson = PlayerPrefs.GetString("UserData");
            return JsonUtility.FromJson<UserData>(userDataJson);
        }
    }
    
    [Serializable]
    public struct UserData
    {
        public int levelNo;
        public static UserData Defaults()
        {
            var defaultData = new UserData();
            defaultData.levelNo = 0;
            return defaultData;
        }
    }
}