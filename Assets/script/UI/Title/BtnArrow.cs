using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnArrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Arrow;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Arrow.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Arrow.SetActive(false);
    }
}
