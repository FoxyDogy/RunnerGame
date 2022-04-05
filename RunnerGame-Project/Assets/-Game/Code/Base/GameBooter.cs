using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Code.Base
{
    public class GameBooter : DataBehaviour
    {
        public void Start()
        {
            var userData = LoadUserData();
            Data.currentUserData = userData;
            if (userData.endlessMode)
            {
               SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
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
            Debug.Log(userDataJson);
            return JsonUtility.FromJson<UserData>(userDataJson);
        }
    }
}