using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    [SerializeField] private Text txt_name;
    [SerializeField] private Image img_name;
    [SerializeField] private Sprite sprite;

    private bool isCoolTime = false;

    private float currentTime = 5f;
    private float delayTime = 5f;

    void Update()
    {
        if(isCoolTime){
            currentTime -= Time.deltaTime;
            img_name.fillAmount = currentTime / delayTime;
        }

        if(currentTime <= 0 )
        {
            isCoolTime = false;
            currentTime = delayTime;
            img_name.fillAmount = currentTime ;
        }

        /*
         * 이미지와 관련된 속성들
         * img_name.sprite = sprite -> 이미지 우리가 설정한 sprite로 바꾸는것
         * img_name.color = Color.red; -> 이미지의 색깔을 변경하는 것
         * Color.a = 0f -> 색상의 투명도를 조절함
         */
    }

    public void Change()
    {
        txt_name.text = "변경됨";
        img_name.fillAmount = 0.5f;

        isCoolTime = true;
    }
}
