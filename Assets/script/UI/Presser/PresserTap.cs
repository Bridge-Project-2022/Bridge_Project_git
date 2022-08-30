using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresserTap : MonoBehaviour
{
    public GameObject EndPoint;
    public GameObject Notes;
    public TextMeshProUGUI result;
    //public void OnLeftBtnClicked()

    [SerializeField]
    Transform[] ChildList;
    public void OnTapBtnClicked(int tapType)
    {
        ChildList = Notes.GetComponentsInChildren<Transform>();

        GameObject NextNote = null;
        foreach (Transform child in ChildList)
        {
            GameObject go = child.gameObject;

            // 부모를 제외 자식만 가져옴.
            if (go.name == "Notes")
                continue;

            if ((int)go.GetComponent<Note>().noteType == tapType)
            {
                NextNote = go;
                break;
            }
        }

        if (NextNote == null)
            return;

        float NextNoteXpos = NextNote.transform.position.x;
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
