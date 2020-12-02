using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTest : MonoBehaviour
{
    private Rigidbody myRigid;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            myRigid.velocity = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.O))
        {
            myRigid.angularVelocity = -Vector3.right;
        }
        if (Input.GetKey(KeyCode.I)) // 폭발실행 (폭발세기, 폭발이 생기는 위치, 폭발 반경)
        {
            myRigid.AddExplosionForce(10, this.transform.right, 10);
        }

        /*
         * 자주 쓰이는 명령어들
         * myRigid.mass=2f; -> 질량을 바꿈
         * myRigid.drag=2f; -> 저항을 바꿈
         * myRigid.angularDrag -> 회전 저항을 바꿈
         * myRigid.maxAngularVelocity -> 최대 회전 속도 기본 7로 설정 되어있음
         * myRigid.useGravity = true -> 중력 활성화, 비활성화 설정
         * myRigid.MovePosition(transform.forward*Time.deltaTime); -> 일정 방향으로 이동시키는 것
         * myRigid.moveRotation(Quaternion.Euler(roatation)); -> 일정 방향으로 회전
         * movePosition과 moveratation은 관성과 질량에 영향받지않고 강제로 이동시킴
         * myRigid.AddForce(Vector3.forward); -> 관성 질량에 영향받고 일정방향으로 이동함
         * myRigid.AddTorque(Vector3.up) -> 관성 질량 저항에 영향받고 방향으로 회전
         */
    }
}
