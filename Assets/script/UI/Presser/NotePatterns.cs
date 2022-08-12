using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePatterns : MonoBehaviour
{
    public Transform NoteStartPos;
    public GameObject NoteParent;
    public GameObject Note;
    
    void Start()
    {
        //GameObject NewNote = Instantiate(Note);
        //NewNote.transform.parent = NoteParent.transform;
        StartCoroutine("FamilyPattern");
    }

    IEnumerator FamilyPattern()
    {
        yield return new WaitForSeconds(1.0f);

        GameObject.Instantiate(Note, NoteStartPos).transform.SetParent(NoteParent.transform);
        yield return new WaitForSeconds(0.6f);

        GameObject.Instantiate(Note, NoteStartPos).transform.SetParent(NoteParent.transform);
        yield return new WaitForSeconds(0.6f);

        GameObject.Instantiate(Note, NoteStartPos).transform.SetParent(NoteParent.transform);
        yield return new WaitForSeconds(0.3f);

        GameObject.Instantiate(Note, NoteStartPos).transform.SetParent(NoteParent.transform);
        yield return new WaitForSeconds(0.3f);

        GameObject.Instantiate(Note, NoteStartPos).transform.SetParent(NoteParent.transform);
        yield return new WaitForSeconds(0.6f);

        GameObject.Instantiate(Note, NoteStartPos).transform.SetParent(NoteParent.transform);
        yield return new WaitForSeconds(0.6f);

        GameObject.Instantiate(Note, NoteStartPos).transform.SetParent(NoteParent.transform);
        yield return new WaitForSeconds(0.3f);

        GameObject.Instantiate(Note, NoteStartPos).transform.SetParent(NoteParent.transform);
        yield return new WaitForSeconds(0.3f);

        GameObject.Instantiate(Note, NoteStartPos).transform.SetParent(NoteParent.transform);
        yield return new WaitForSeconds(0.6f);

        yield return null;
    }
}
