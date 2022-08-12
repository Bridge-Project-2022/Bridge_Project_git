using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresserTap : MonoBehaviour
{
    public GameObject EndPoint;
    public GameObject Notes;
    public void OnLeftBtnClicked()
    {
        GameObject NextNote = Notes.transform.GetChild(0).gameObject;
        float NextNoteXpos = NextNote.transform.position.x;

        if (NextNote == null)
            return;

        float distance = Mathf.Abs(NextNoteXpos - EndPoint.transform.position.x);

        if (distance > 250.0f)
            return;

        if (distance > 200.0f)
        {
            Debug.Log("Miss...");
        }
        else if (distance > 150.0f)
        {
            Debug.Log("Bad");
        }
        else if (distance > 100.0f)
        {
            Debug.Log("Good");
        }
        else
        {
            Debug.Log("Perfect!");
        }

        Destroy(NextNote);
    }
}
