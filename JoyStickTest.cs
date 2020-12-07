using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickTest : MonoBehaviour , IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform rect_Background;
    [SerializeField] private RectTransform rect_Joystick;

    private float radius; //rect_Background의 반지름

    [SerializeField] private GameObject go_Player;
    [SerializeField] private float moveSpeed;

    private bool isTouch = false;
    private Vector3 movePosition;


    // Start is called before the first frame update
    void Start()
    {
        radius = rect_Background.rect.width * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
            go_Player.transform.position += movePosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_Background.position;
        value = Vector2.ClampMagnitude(value, radius); // value값을 반지름을 넘지 않도록 가두기
        rect_Joystick.localPosition = value; // 부모 객체와의 거리를 value만큼 해라


        float distance = Vector2.Distance(rect_Background.position, rect_Joystick.position) / radius; // 조이스틱을 멀리 잡아당길수록 속도 조절하기 위해 거리 차이값을 구해줌



        value = value.normalized; // value의 속도값은 빠지고 방향값만 남게됨
        movePosition = new Vector3(value.x * moveSpeed * distance * Time.deltaTime, 0f, value.y * moveSpeed *distance* Time.deltaTime); // joystick 방향으로 player의 위치값을 옮김
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rect_Joystick.localPosition = Vector3.zero;
        movePosition = Vector3.zero;
    }
}
