using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject DeletePoint;
    float speed = 900.0f;

    void Awake()
    {
        DeletePoint = GameObject.Find("DeletePoint").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0.0f);

        if (transform.position.x < DeletePoint.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }
}
