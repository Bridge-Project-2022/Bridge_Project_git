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
    private void Update()
    {
        /*if (Presser.FindObjectOfType<Presser>().GetComponent<Presser>().ClickedItem.name == "����")
        {
            if (DestroyCnt == 7)
            {
                Presser.FindObjectOfType<Presser>().GetComponent<Presser>().PresserEnd();
            }
        }*/
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
        //���⿡ ���� ��Ʈ �߰��ؾ���. �ٵ� �̰� �׽�Ʈ�� ����Ͽ����� ������

        yield return null;
    }

    IEnumerator LoverPattern()
    {
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
        //���⿡ ���� ��Ʈ �߰��ؾ���. �ٵ� �̰� �׽�Ʈ�� ����Ͽ����� ������

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
        //���⿡ ���� ��Ʈ �߰��ؾ���. �ٵ� �̰� �׽�Ʈ�� ����Ͽ����� ������

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
        //���⿡ ���� ��Ʈ �߰��ؾ���. �ٵ� �̰� �׽�Ʈ�� ����Ͽ����� ������

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
