using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresserTap : MonoBehaviour
{
    public GameObject EndPoint;
    public GameObject Notes;
    public TextMeshProUGUI result;
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
            result.color = new Color32(255,  0, 0, 255);
            result.text = "Miss...";
        }
        else if (distance > 150.0f)
        {
            Debug.Log("Bad");
            result.color = new Color32(255, 0, 0, 255);
            result.text = "Bad";
        }
        else if (distance > 100.0f)
        {
            Debug.Log("Good");
            result.color = new Color32(0, 0, 255, 255);
            result.text = "Good";
        }
        else
        {
            Debug.Log("Perfect!");
            result.color = new Color32(0, 0, 255, 255);
            result.text = "Perfect!";
        }

        Destroy(NextNote);
    }
}
