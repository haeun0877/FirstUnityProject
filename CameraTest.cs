using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    private Camera theCam;

    [SerializeField]
    private GameObject go_Target;

    [SerializeField]
    private float speed;

    private Vector3 difValue;

    // Start is called before the first frame update
    void Start()
    {
        difValue = transform.position - go_Target.transform.position;
        //mathf.abs는 값의 절댓값을 구함 음수는 양수로 바꿈
        difValue = new Vector3(Mathf.Abs(difValue.x), Mathf.Abs(difValue.y), Mathf.Abs(difValue.z)); 

        /*
         * 카메라의 기능들
         * theCam.fieldOfView = 10 -> 보이는 시야 조절 (멀리, 가깝게)
         * theCam.clearFlas -> deapsonly, sky  등으로 바꿀수있음
         * */

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, go_Target.transform.position + difValue, speed);
    }
}
