using TMPro;
using UnityEngine;

namespace _Game.Code.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LifeCountText : MonoBehaviour
    {
        private TextMeshProUGUI countText;

        private void Awake()
        {
            countText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            CharacterController.Instance.onLifeUpdate += LifeUpdate;
            countText.text = CharacterController.Instance.LifeCount.ToString();
        }

        private void LifeUpdate(int lifeCount)
        {
            countText.text = lifeCount.ToString();
        }
    }
}