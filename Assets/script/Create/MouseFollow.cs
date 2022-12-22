using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseFollow : MonoBehaviour
{
    public RectTransform transform_icon;
    //public Text text_mouse;
    private void Start()
    {
        Init_Cursor();
    }
    private void Update()
    {
        Update_MousePosition();
    }

    private void Init_Cursor()
    {
        //Cursor.visible = false;

        if (transform_icon.GetComponent<Graphic>())
            transform_icon.GetComponent<Graphic>().raycastTarget = false;
    }

    private void Update_MousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        float w = transform_icon.rect.width;
        float h = transform_icon.rect.height;
        transform_icon.position = mousePos;
        //transform_icon.position = mousePos + (new Vector2(w, h) * 0.5f);

        //string message = mousePos.ToString();
        //text_mouse.text = message;
        //Debug.Log(message);
    }
}
