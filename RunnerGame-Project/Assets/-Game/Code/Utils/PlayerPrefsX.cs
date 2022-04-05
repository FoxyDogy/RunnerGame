using UnityEngine;

namespace _Game.Code.Utils
{
    public class PlayerPrefsX : MonoBehaviour
    {
        public static bool SetBool(string name, bool value)
        {
            try
            {
                PlayerPrefs.SetInt(name, value ? 1 : 0);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool GetBool(string name)
        {
            return PlayerPrefs.GetInt(name) == 1;
        }

        public static bool GetBool(string name, bool defaultValue)
        {
            return 1 == PlayerPrefs.GetInt(name, defaultValue ? 1 : 0);
        }
    }
}