using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    [SerializeField] private float fadeTime;
    [SerializeField] private GameObject backGround;
    private void Awake()
    {
        //StartCoroutine(SetBackGround());
    }
    
    private IEnumerator SetBackGround()
    {
        yield return new WaitForSeconds(fadeTime);
        Debug.Log("?!");
        backGround.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void SetUp(ToolTip toolTip)
    {
        StartCoroutine(SetBackGround());
    }
}
