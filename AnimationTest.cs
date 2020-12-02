using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            /*
            anim.Play("Cube2"); //시작하자마자 cube2가 실행
            anim.PlayQueued("Cube2"); //실행중이던 에니매이션(cube)가 끝나고 재생
            anim.Blend("Cube2"); // 실행중인 애니메이션과 합쳐서 재생
            if(!anim.IsPlaying("Cube2")) //cube2가 실행중이지 않으면
            {
                anim.Play("Cube2");
            }
            */

            anim.CrossFade("Cube2"); //실행중인 애니메이션에서 자연스럽게 cube2로 넘어감
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.Stop();
        }
    }
}
