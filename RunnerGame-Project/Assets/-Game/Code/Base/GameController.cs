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

    public class GameController : Singleton<GameController>
    {
        private bool endGame;
        public GameState GameState { get; private set; }
        public event Action<UserData> onBootGame;
        public event Action onBootGameCompleted;
        public event Action onStartGame;
        public event Action<bool> onEndGame;
        public UserData currentUserData;
        private void Start()
        {
            Application.targetFrameRate = 165;
            GameState = GameState.Boot;
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
            GameState = GameState.Game;
            onStartGame?.Invoke();
        }
        public void EndGame(bool state)
        {
            if (endGame) return;

            endGame = true;
            if (state)
                GameState = GameState.Win;
            else
                GameState = GameState.Fail;
            onEndGame?.Invoke(state);
        }

        public void NextLevel()
        {
            currentUserData.levelNo++;
            SaveUserData();
            SceneManager.LoadScene(0);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
        
        private void SaveUserData()
        {
            var json = JsonUtility.ToJson(currentUserData);
            PlayerPrefs.SetString("UserData",json);
        }
        private UserData LoadUserData()
        {
            if (!PlayerPrefs.HasKey("UserData"))
            {
                currentUserData = UserData.Defaults();
                var jsonData = JsonUtility.ToJson(currentUserData);
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