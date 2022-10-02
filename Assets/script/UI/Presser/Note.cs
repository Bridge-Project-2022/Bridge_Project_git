using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject DeletePoint;
    public NoteType noteType;
    float speed = 900.0f;
    void Awake()
    {
        DeletePoint = GameObject.Find("DeletePoint").gameObject;
    }

    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0.0f);

        if (transform.position.x < DeletePoint.transform.position.x)
        {
            Debug.Log("삭제");
            Destroy(this.gameObject);
        }
    }

    public enum NoteType
    {
        Left,
        Right,
        Both,
        Long,
        LongBoth
    }
}
