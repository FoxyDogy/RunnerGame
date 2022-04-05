using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class NumberCounter : MonoBehaviour
{
    private bool activate;
    private float currentNumber;
    private float desiredNumber;
    private float duration = 1;
    private float initialNumber;
    private TextMeshProUGUI Text;

    private void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!activate) return;
        if (currentNumber != desiredNumber)
        {
            if (initialNumber < desiredNumber)
            {
                currentNumber += Time.deltaTime * (desiredNumber - initialNumber);
                if (currentNumber >= desiredNumber)
                {
                    currentNumber = desiredNumber;
                    activate = false;
                }
            }
            else
            {
                currentNumber -= Time.deltaTime * (initialNumber - desiredNumber);
                if (currentNumber <= desiredNumber)
                {
                    currentNumber = desiredNumber;
                    activate = false;
                }
            }

            Text.text = currentNumber.ToString("0");
        }
    }

    public void SetNumber(float value, float duration = 1)
    {
        this.duration = duration;
        initialNumber = int.Parse(Text.text);
        currentNumber = initialNumber;
        desiredNumber = value;
        activate = true;
    }
}