using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rigid;
    private BoxCollider col;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask layerMask;

    private bool isMove;
    private bool isJump;
    private bool isFall;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        TryWalk();
        TryJump();
    }

    private void TryWalk()
    {
        // horizontal = 수평 = a,d키 혹은 마우스 왼쪽 오른쪽키를 뜻함.
        // 오른쪽이 눌리면 1리턴, 아무것도 안눌리면 0리턴, 왼쪽이 눌리면 -1을 리턴함
        float _dirX = Input.GetAxisRaw("Horizontal");
        float _dirZ = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(_dirX, 0, _dirZ);

        /*
        anim.SetBool("Right", false);
        anim.SetBool("Left", false);
        anim.SetBool("Up", false);
        anim.SetBool("Down", false);
        */
        isMove = false;


        if (direction != Vector3.zero) //아무것도 안누른다면 vector3.zero가 되고 하나의 키라도 눌린다면 if문 성립
        {
            isMove = true;
            //대각선으로 이동할때 1+1이 되어서 2가되는 걸 방지하기 위해 방향값만 나타나게함 (총합을 1로만들기위해서)
            this.transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
            /*
            if (direction.x > 0)
                anim.SetBool("Right", true);
            else if (direction.x < 0)
                anim.SetBool("Left", true);
            else if (direction.z > 0)
                anim.SetBool("Up", true);
            else if (direction.z < 0)
                anim.SetBool("Down", true);
            */
        }

        anim.SetBool("Move", isMove);
        anim.SetFloat("DirX", direction.x);
        anim.SetFloat("DirZ", direction.z);
    }

    private void TryJump()
    {
        if (isJump)
        {
            if(rigid.velocity.y >= -0.1 && !isFall) //velocity가 음수인 경우에는 추락하고 있다는 뜻 (점프중일때는 플러스가 되기때문)
            {
                isFall = true;
                anim.SetTrigger("Fall");
            }

            RaycastHit hitInfo; //땅에 닿았는지 체크하기 위해서 레이저를 쏴서 정보를 저장하는 raycasthit 이용
            if (Physics.Raycast(transform.position, -transform.up, out hitInfo, col.bounds.extents.y + 0.1f, layerMask)) //Raycast는 모든 콜라이더와 충돌했을때 true가됨
            {
                anim.SetTrigger("Landing");
                isJump = false;
                isFall = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isJump) // 두번의 점프를 못하게 하기위해서 isJump를 체크해준다
        {
            isJump = true;
            rigid.AddForce(Vector3.up * jumpForce);
            //rigid.velocity = new Vector3(0, jumpForce, 0); //이것도 똑같은 방법임
            anim.SetTrigger("Jump");
        }
    }
}
