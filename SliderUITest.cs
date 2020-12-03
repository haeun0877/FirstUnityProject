using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUITest : MonoBehaviour
{

    [SerializeField] private Slider slider;

    private bool isClick = false;

    private float dotTime = 1f;
    private float currentDotTime = 0f;

    void Start()
    {
        currentDotTime = dotTime;
    }

    private void Update()
    {
        if (isClick)
            slider.value -= Time.deltaTime;
    }

    public void Button()
    {
        isClick = true;
    }

    
}
