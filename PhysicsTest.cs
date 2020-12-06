using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    //player가 일정 범위 안에 들어오면 방향을 player쪽으로 바꾸고 총알 발사
    private float createTime = 1f;
    private float currentCreateTime;

    [SerializeField] private GameObject go_BulletPrefeb;

    void Update()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, 5f);

        if (col.Length > 0)
        {
            for (int i = 0; i < col.Length; i++)
            {
                Transform tf_Target = col[i].transform;

                if (tf_Target.tag == "Player")
                {
                    Quaternion rotation = Quaternion.LookRotation(tf_Target.position - this.transform.position);
                    transform.rotation = rotation;
                    currentCreateTime += Time.deltaTime;

                    if(currentCreateTime >= createTime)
                    {
                        GameObject _temp = Instantiate(go_BulletPrefeb, transform.position, rotation);
                        // 총알 _temp와 player 간의 충돌을 무시하도록 하는 코드
                        //Physics.IgnoreCollision(_temp.GetComponent<Collider>(), tf_Target.GetComponent<Collider>()); 
                        currentCreateTime = 0;
                    }
                }
            }
        }
    }

    /*
     * enemy가 player를 바라볼때 1초마다 하나씩 총알 발사
    [SerializeField] private GameObject go_BulletPrefab;
    [SerializeField] private LayerMask layerMask;

    private float createTime = 1f;
    private float currentCreateTime = 0;
    // Update is called once per frame
    void Update()
    {
        currentCreateTime += Time.deltaTime;
        if(currentCreateTime>=createTime)
        {
            currentCreateTime = 0f;

            RaycastHit hitInfo;

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 10f, layerMask))
            {
                if(hitInfo.transform.tag == "Player")
                {
                    Instantiate(go_BulletPrefab, transform.position, Quaternion.LookRotation(hitInfo.transform.position - transform.position));
                }
            }
        }
    }
    */
}
