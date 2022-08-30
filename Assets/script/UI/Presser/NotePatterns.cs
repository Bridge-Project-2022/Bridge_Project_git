using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePatterns : MonoBehaviour
{
    public Transform NoteStartPos;
    public GameObject NoteParent;
    public GameObject Note;

    void Start()
    {
        StartCoroutine("FamilyPattern");
    }

    IEnumerator FamilyPattern()
    {
        yield return new WaitForSeconds(1.0f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.3f);

        CreateRightNote();
        yield return new WaitForSeconds(0.3f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.3f);

        CreateRightNote();
        yield return new WaitForSeconds(0.3f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        yield return null;
    }

    GameObject CreateLeftNote()
    {
        GameObject go = Instantiate(Note, NoteStartPos);
        Note note = go.GetComponent<Note>();

        go.transform.SetParent(NoteParent.transform);
        note.noteType = global::Note.NoteType.Left;
        return go;
    }

    GameObject CreateRightNote()
    {
        GameObject go = Instantiate(Note, NoteStartPos);
        Note note = go.GetComponent<Note>();

        go.transform.SetParent(NoteParent.transform);
        go.GetComponent<Image>().color = new Color(0, 0, 1.0f);
        note.noteType = global::Note.NoteType.Right;
        return go;
    }
}
