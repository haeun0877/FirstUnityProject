using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderTest : MonoBehaviour
{

    private BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //0은 마우스 좌버튼
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 좌표에 (mousePosition) 레이저를 쏘는것
            RaycastHit hitInfo; //레이저를 쏴서 맞은 곳에 대한 정보
            if(col.Raycast(ray, out hitInfo, 1000))
            {
                this.transform.position = hitInfo.point;
            }
        }

        
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("col.bounds = " + col.bounds);
            Debug.Log("col.bounds.extents = " + col.bounds.extents);
            Debug.Log("col.bounds.extents.x = " + col.bounds.extents.x);
            Debug.Log("col.size = " + col.size);
            Debug.Log("col.center = " + col.center);
        }
     }*/

    
    //trigger가 체크된 상태에서 다른 콜라이더와 부딪혔을때 실행
    private void OnTriggerEnter(Collider other)
    {
        
    }

    //trigger가 체크된 상태에서 다른 콜라이더와 충돌이 끝났을 때 실행
    private void OnTriggerExit(Collider other)
    {
        other.transform.position += new Vector3(0, 2, 0);
    }

    //trigger가 체크된 상태에서 충돌이 계속 진행되고 있을 때 실행
    private void OnTriggerStay(Collider other)
    {
        other.transform.position += new Vector3(0, 0, 0.01f);
    }
    

    /*
    //직접 충돌하였을 때 발생하는 함수들
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
    */
}
