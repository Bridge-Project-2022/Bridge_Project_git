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
        Debug.Log("�巡�� ����");

        startPos.y = eventData.position.y;//���콺 y��

        offset.x = transform.position.x;// �ڵ� y��
        offset.y = transform.position.y;// �ڵ� y��
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�� ��������");
        Vector2 downDirection = eventData.position - startPos;//ó�� Ŭ�� ��ġ���� �����̴� ���콺 ��ġ ���� �Ÿ�
        Debug.Log(transform.position);
        downDirection.Normalize();

        if (isUP == true && transform.position.y < 715 && transform.position.y > 620)
        {
            Debug.Log("������");
            transform.position = new Vector2(offset.x, transform.position.y + downDirection.y * 15);

        }
        else if (isUP == true && transform.position.y <= 620 && transform.position.y >= 600)
        {
            Debug.Log("����");
            isUP = false;
        }
        else if (isUP == false)
        {
            Debug.Log("�ö�");
            transform.position = new Vector2(offset.x, transform.position.y - downDirection.y * 15);
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("�巡�� ������");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�� ��");
    }
}
