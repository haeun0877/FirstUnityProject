using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Vector3 rotation;

    void Start()
    {
        rotation = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W)) // w키 눌렀을 때 자리이동
        {
            //1번째 방법
            //this.transform.position = this.transform.position + new Vector3(0, 0, 1) * Time.deltaTime; //대략 60분의 1
            //2번째 방법
            this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q)) // q키 눌렀을 때 회전
        {
            //이 방법은 90도 이상부터 이상하게 동작함 -> this.transform.eulerAngles이 이상한 값이 되는데 그것을 계속 더하기 때문 -> 초기화해서 사용해야함
            //this.transform.eulerAngles = this.transform.eulerAngles + new Vector3(90, 0, 0) * Time.deltaTime;
            rotation = rotation + new Vector3(90, 0, 0) * Time.deltaTime;
            this.transform.eulerAngles = rotation;

            //2번째 방법 ->좀더 간단함 rotation을 따로 선언할 필요없음  
            //this.transform.Rotate(new Vector3(90,0,01)*Time.deltaTime;
        }

    }
}
