using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PresserDrag : MonoBehaviour, IBeginDragHandler,IDragHandler, IDropHandler, IEndDragHandler
{
    Vector2 offset;
    Vector2 startPos = Vector2.zero;

    public bool isUP = true;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("드래그 시작");

        startPos.y = eventData.position.y;//마우스 y축

        offset.x = transform.position.x;// 핸들 y축
        offset.y = transform.position.y;// 핸들 y축
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("드래그 가능해짐");
        Vector2 downDirection = eventData.position - startPos;//처음 클릭 위치에서 움직이는 마우스 위치 사이 거리
        Debug.Log(transform.position);
        downDirection.Normalize();

        if (isUP == true && transform.position.y < 715 && transform.position.y > 620)
        {
            Debug.Log("내려감");
            transform.position = new Vector2(offset.x, transform.position.y + downDirection.y * 15);

        }
        else if (isUP == true && transform.position.y <= 620 && transform.position.y >= 600)
        {
            Debug.Log("멈춤");
            isUP = false;
        }
        else if (isUP == false)
        {
            Debug.Log("올라감");
            transform.position = new Vector2(offset.x, transform.position.y - downDirection.y * 15);
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("드래그 내려둠");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("드래그 끝");
    }
}
