using _Game.Code.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Code.Base
{
    public class GameBooter : DataBehaviour
    {
        public void Start()
        {
            var endlessMode = PlayerPrefsX.GetBool("endlessMode", false);

            if (endlessMode)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}