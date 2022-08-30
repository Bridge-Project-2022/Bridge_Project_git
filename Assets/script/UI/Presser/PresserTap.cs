using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresserTap : MonoBehaviour
{
    public GameObject EndPoint;
    public GameObject Notes;

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
