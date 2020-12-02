using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private GameObject go_camera; //private를 하면 인스펙터창에 go_camera가 안뜨기 때문에 serializefield를 선언

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

        if (Input.GetKey(KeyCode.S)) // s키 눌렀을때 스케일 조절
        {
            this.transform.localScale = this.transform.localScale + new Vector3(2, 2, 2) * Time.deltaTime;
        }

        /*
         * 대표적인 명령어
         * this. transform. forward * Time.deltaTIme; //new Vector3(0,0,1) -> 앞으로 전진함 (스피드를 바꾸고싶으면 movespeed변수를 선언해서 곱하면됨
         * this. trnasform. up * Time.deltaTime; // 위로 올라감
         * this. transform. right * Time.deltaTime; // 오른쪽으로
         * this. transform. Rotate()
         * this. transform. Translate()
         * this. transform. LooAt () // 어떤 게임 오브젝트쪽을 바라보게 만드는 것
         * */

        if (Input.GetKey(KeyCode.R)) // R키를 눌렀을 때 게임 오브젝트를 바라봄
        {
            this.transform.LookAt(go_camera.transform.position);
        }


        //카메라 중심으로 계속 돌게만듬
        //transform.RotateAround(go_camera.transform.position, Vector3.up, 100 * Time.deltaTime);

    }
}
