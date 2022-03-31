using UnityEngine;

namespace Foxy.Utils
{
    public class DontDestroy : MonoBehaviour
    {
        private DontDestroy instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }

            Destroy(gameObject);
        }
    }
}