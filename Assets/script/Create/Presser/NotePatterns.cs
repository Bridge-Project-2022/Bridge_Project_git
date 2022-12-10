using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePatterns : MonoBehaviour
{
    public Transform NoteStartPos;
    public GameObject NoteParent;
    public GameObject Note;

    public Sprite LeftNote;
    public Sprite MiddleNote;
    public Sprite RightNote;

    public int DestroyCnt = 0;
    void Start()
    {
        //StartCoroutine("FamilyPattern");
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
        //여기에 양쪽 노트 추가해야함. 근데 이거 테스트는 모바일에서만 가능임

        yield return null;
    }

    IEnumerator LoverPattern()
    {
        Debug.Log("연인");
        yield return new WaitForSeconds(1.0f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.2f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.6f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.2f);

        CreateRightNote();
        yield return new WaitForSeconds(0.6f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.3f);

        CreateRightNote();
        yield return new WaitForSeconds(0.2f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.3f);
        //여기에 양쪽 노트 추가해야함. 근데 이거 테스트는 모바일에서만 가능임

        yield return null;
    }

    IEnumerator PetPattern()
    {
        yield return new WaitForSeconds(1.0f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.3f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.3f);

        CreateRightNote();
        yield return new WaitForSeconds(0.4f);

        CreateRightNote();
        yield return new WaitForSeconds(0.6f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.3f);

        CreateRightNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.3f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.4f);
        //여기에 양쪽 노트 추가해야함. 근데 이거 테스트는 모바일에서만 가능임

        yield return null;
    }

    IEnumerator ParkPattern()
    {
        yield return new WaitForSeconds(1.0f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.5f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.2f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.3f);

        CreateRightNote();
        yield return new WaitForSeconds(0.5f);

        CreateRightNote();
        yield return new WaitForSeconds(0.2f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.4f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);
        //여기에 양쪽 노트 추가해야함. 근데 이거 테스트는 모바일에서만 가능임

        yield return null;
    }

    IEnumerator FriendPattern()
    {
        yield return new WaitForSeconds(1.0f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.5f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.2f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.3f);

        CreateRightNote();
        yield return new WaitForSeconds(0.5f);

        CreateRightNote();
        yield return new WaitForSeconds(0.2f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.4f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);
        //여기에 양쪽 노트 추가해야함. 근데 이거 테스트는 모바일에서만 가능임

        yield return null;
    }

    IEnumerator ToyPattern()
    {
        yield return new WaitForSeconds(1.0f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.5f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.2f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.3f);

        CreateRightNote();
        yield return new WaitForSeconds(0.5f);

        CreateRightNote();
        yield return new WaitForSeconds(0.2f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.4f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);
        //여기에 양쪽 노트 추가해야함. 근데 이거 테스트는 모바일에서만 가능임

        yield return null;
    }

    IEnumerator DollPattern()
    {
        yield return new WaitForSeconds(1.0f);

        CreateRightNote();
        yield return new WaitForSeconds(0.6f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.2f);

        CreateRightNote();
        yield return new WaitForSeconds(0.5f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.3f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.5f);

        CreateRightNote();
        yield return new WaitForSeconds(0.5f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.7f);

        CreateRightNote();
        yield return new WaitForSeconds(0.7f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.8f);

        //여기에 양쪽 노트 추가해야함. 근데 이거 테스트는 모바일에서만 가능임

        yield return null;
    }

    IEnumerator SchoolPattern()
    {
        yield return new WaitForSeconds(1.0f);

        CreateRightNote();
        yield return new WaitForSeconds(0.6f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.2f);

        CreateRightNote();
        yield return new WaitForSeconds(0.5f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.3f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.5f);

        CreateRightNote();
        yield return new WaitForSeconds(0.5f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.7f);

        CreateRightNote();
        yield return new WaitForSeconds(0.7f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.8f);

        //여기에 양쪽 노트 추가해야함. 근데 이거 테스트는 모바일에서만 가능임

        yield return null;
    }

    IEnumerator PlayGroundPattern()
    {
        yield return new WaitForSeconds(1.0f);

        CreateRightNote();
        yield return new WaitForSeconds(0.6f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.2f);

        CreateRightNote();
        yield return new WaitForSeconds(0.5f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.3f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.5f);

        CreateRightNote();
        yield return new WaitForSeconds(0.5f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.7f);

        CreateRightNote();
        yield return new WaitForSeconds(0.7f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.8f);

        //여기에 양쪽 노트 추가해야함. 근데 이거 테스트는 모바일에서만 가능임

        yield return null;
    }

    IEnumerator TravelPattern()
    {
        yield return new WaitForSeconds(1.0f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateRightNote();
        yield return new WaitForSeconds(0.6f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.3f);

        CreateRightNote();
        yield return new WaitForSeconds(0.2f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.3f);

        CreateRightNote();
        yield return new WaitForSeconds(0.2f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.3f);

        CreateRightNote();
        yield return new WaitForSeconds(0.6f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.6f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.3f);

        CreateRightNote();
        yield return new WaitForSeconds(0.2f);

        CreateLeftNote();
        yield return new WaitForSeconds(0.3f);

        //여기에 양쪽 노트 추가해야함. 근데 이거 테스트는 모바일에서만 가능임

        yield return null;
    }

    GameObject CreateLeftNote()
    {
        GameObject go = Instantiate(Note, NoteStartPos);
        Note note = go.GetComponent<Note>();

        go.transform.SetParent(NoteParent.transform);
        go.GetComponent<Image>().sprite = LeftNote;
        go.GetComponent<Image>().SetNativeSize();
        note.noteType = global::Note.NoteType.Left;
        return go;
    }

    GameObject CreateRightNote()
    {
        GameObject go = Instantiate(Note, NoteStartPos);
        Note note = go.GetComponent<Note>();

        go.transform.SetParent(NoteParent.transform);
        go.GetComponent<Image>().sprite = RightNote;
        go.GetComponent<Image>().SetNativeSize();
        note.noteType = global::Note.NoteType.Right;
        return go;
    }
}
