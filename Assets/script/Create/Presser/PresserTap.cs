using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PresserTap : MonoBehaviour
{
    public GameObject EndPoint;
    public GameObject Notes;
    public TextMeshProUGUI result;
    //public void OnLeftBtnClicked()

    public GameObject CatPress;
    public Sprite[] PressReaction = new Sprite[13];

    [SerializeField]
    Transform[] ChildList;

    public bool isPressDown = false;
    public void Update()
    {
        CatPress.gameObject.GetComponent<Image>().SetNativeSize();
        //CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[0];
    }
    /*public void OnTapBtnClicked(int tapType)
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
        {
            CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[0];
            return;
        }

        if (distance > 200.0f)
        {
            if (tapType == 0 && isPressDown == true)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[10];
            if (tapType == 1 && isPressDown == true)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[12];
            Debug.Log("Miss...");
            
        }
        else if (distance > 150.0f)
        {
            if (tapType == 0 && isPressDown == true)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[7];
            if (tapType == 1 && isPressDown == true)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[9];
            Debug.Log("Bad");

        }
        else if (distance > 100.0f)
        {
            if (tapType == 0 && isPressDown == true)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[4];
            if (tapType == 1 && isPressDown == true)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[6];
            Debug.Log("Good");
        }
        else
        {
            if (tapType == 0 && isPressDown == true)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[1];
            if (tapType == 1 && isPressDown == true)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[3];
            Debug.Log("Perfect!");
        }

        Destroy(NextNote);
    }*/

    public void PressDown(int tapType)
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
        {
            CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[0];
            return;
        }

        if (distance > 200.0f)
        {
            if (tapType == 0)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[10];
            if (tapType == 1)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[12];
            Presser.FindObjectOfType<Presser>().PressureScore += 1;
            Destroy(NextNote);
            Debug.Log("Miss...");

        }
        else if (distance > 150.0f)
        {
            if (tapType == 0)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[7];
            if (tapType == 1)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[9];
            Presser.FindObjectOfType<Presser>().PressureScore += 2;
            Destroy(NextNote);
            Debug.Log("Bad");

        }
        else if (distance > 100.0f)
        {
            if (tapType == 0)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[4];
            if (tapType == 1)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[6];
            Presser.FindObjectOfType<Presser>().PressureScore += 3;
            Destroy(NextNote);
            Debug.Log("Good");
        }
        else
        {
            if (tapType == 0)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[1];
            if (tapType == 1)
                CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[3];
            Presser.FindObjectOfType<Presser>().PressureScore += 4;
            Destroy(NextNote);
            Debug.Log("Perfect!");
        }

        //GameObject.Find("NoteLine").GetComponent<NotePatterns>().DestroyCnt++;

    }

    public void PressUp()
    {
        CatPress.gameObject.GetComponent<Image>().sprite = PressReaction[0];
    }
}
