using UnityEngine;

namespace _Game.Code.Base
{
    public class DataBehaviour<T> : MonoBehaviour  where T : MonoBehaviour
    {
        private static T instance;

        private GameData gameData;

        public static T Instance
        {
            get
            {
                if (instance == null) instance = FindObjectOfType<T>();
                return instance;
            }
        }

        internal GameData Data
        {
            get
            {
                if (!gameData) gameData = Resources.Load<GameData>("GameData");

                return gameData;
            }
        }

     
        public void InspectorInit()
        {
            gameData = Resources.Load<GameData>("GameData");
        }
    }
    public class DataBehaviour: MonoBehaviour
    {
        private GameData gameData;
        
        internal GameData Data
        {
            get
            {
                if (!gameData) gameData = Resources.Load<GameData>("GameData");

                return gameData;
            }
        }

     
        public void InspectorInit()
        {
            gameData = Resources.Load<GameData>("GameData");
        }
    }
}