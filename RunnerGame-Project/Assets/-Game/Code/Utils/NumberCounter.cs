using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class NumberCounter : MonoBehaviour
{
    private TextMeshProUGUI Text;
    private float duration = 1;
    private float desiredNumber;
    private float initialNumber;
    private float currentNumber;
    private bool activate;

    private void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    public void SetNumber(float value,float duration=1)
    {
        this.duration = duration;
        initialNumber = int.Parse(Text.text);
        currentNumber = initialNumber;
        desiredNumber = value;
        activate = true;
    }

    private void Update()
    {
        if (!activate)
        {
           return; 
        }
        if (currentNumber != desiredNumber)
        {
            if (initialNumber<desiredNumber)
            {
                currentNumber += (Time.deltaTime) * (desiredNumber - initialNumber);
                if (currentNumber>= desiredNumber)
                {
                    currentNumber = desiredNumber;
                    activate = false;
                }
            }
            else
            {
                currentNumber -= (Time.deltaTime) * (initialNumber - desiredNumber);
                if (currentNumber <= desiredNumber)
                {
                    currentNumber = desiredNumber;
                    activate = false;

                }
            }

            Text.text = currentNumber.ToString("0");
        }
    }
}