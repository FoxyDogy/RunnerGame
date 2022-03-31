using System.Collections;
using System.IO;
using _Game.Code.Utils;
using UnityEngine;

namespace _Game.Code.Base
{
    public class LevelLoader : MonoBehaviour
    {
        //TODO: Data Config
        public bool autoLevelLoad=true;
        public string[] levels;
        public int loopLevel;
        public GameObject levelGo;
        private void OnEnable()
        {
            GameController.Instance.onBootGame += BootGame;
        }

        private void BootGame(UserData obj)
        {
            var level = obj.levelNo;
            LoadLevel(level);
        }

        public void LoadLevel(int levelNo)
        {
            if (autoLevelLoad)
            {
                var lvl = levelNo;
                var maxLevel = levels.Length - 1;
                if (levelNo > maxLevel)
                    lvl = (levelNo - 1) % (maxLevel - loopLevel + 1) +
                          loopLevel;

                var levelName = levels[lvl];
                StartCoroutine(LoadLevelIE(Path.Combine("LevelPrefabs", levelName)));
            }
            else
            {
                GameController.Instance.BootGameCompleted();
            }
        }

        private IEnumerator LoadLevelIE(string path)
        {
            var request = Resources.LoadAsync(path);
            yield return request;
            levelGo = Instantiate((GameObject) request.asset);
            Resources.UnloadUnusedAssets();
            GameController.Instance.BootGameCompleted();
        }
    }
}