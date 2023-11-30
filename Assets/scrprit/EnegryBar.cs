using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EnegryBar : MonoBehaviour
{
    public static EnegryBar Instance;
    public Slider slider;
    public Text energyText;
    public float timer = 0.0f;
    public int EnegryValue = 0;
    public float maxTime = 0.0f;
    public int maxEnegryValue = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameObject healBarObject = GameObject.Find("healbar");
        energyText.text = "EnegryValue: " + EnegryValue.ToString();
    }

    private void Update()
    {
        SetTimerValue();
        timer += Time.deltaTime;

        if (timer >= maxTime)
        {
            timer = 0.0f;
            EnegryValue = Mathf.Min(EnegryValue + 1, maxEnegryValue);
            UpdateEnergyTextLabel();
        }
    }

    public void SetTimerValue()
    {
        if (maxTime > 0)
        {
            slider.value = Mathf.Clamp01(timer / maxTime);
        }
    }

    public void UpdateEnergyTextLabel()
    {
        energyText.text = "Enegry Value : " + EnegryValue.ToString();
    }
}
