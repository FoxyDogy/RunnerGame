using System.Collections;
using System.IO;
using UnityEngine;

namespace _Game.Code.Base
{
    public class LevelLoader : DataBehaviour
    {
        public bool autoLevelLoad = true;
        public string[] levels;
        public int loopLevel;
        public GameObject levelGo;

        private void OnEnable()
        {
            GameController.Instance.onBootGame += LoadLevel;
            GameController.Instance.onEndGame += IncreaseLevelNumber;
        }

        private void IncreaseLevelNumber(bool obj)
        {
            Data.currentUserData.levelNo++;
        }

        public void LoadLevel()
        {
            var levelNo = Data.currentUserData.levelNo;
            if (autoLevelLoad)
            {
                var lvl = levelNo;
                var maxLevel = levels.Length - 1;
                if (levelNo > maxLevel)
                    lvl = (levelNo - 1) % (maxLevel - loopLevel + 1) +
                          loopLevel;

                var levelName = levels[lvl];
                StartCoroutine(LoadLevelAsync(Path.Combine("LevelPrefabs", levelName)));
            }
            else
            {
                GameController.Instance.BootGameCompleted();
            }
        }

        private IEnumerator LoadLevelAsync(string path)
        {
            var request = Resources.LoadAsync(path);
            yield return request;
            levelGo = Instantiate((GameObject) request.asset);
            Resources.UnloadUnusedAssets();
            GameController.Instance.BootGameCompleted();
        }
    }
}