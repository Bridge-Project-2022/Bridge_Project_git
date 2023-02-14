using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointChange : MonoBehaviour
{
    [Header("ObjectImage")]
    private Image _image;
    [SerializeField] private Sprite defaultImage;
    [SerializeField] private Sprite enterImage;
    
    [Header("TextObject")]
    [SerializeField] private GameObject text;

    private void Start()
    {
        _image = GetComponent<Image>();
        text.SetActive(false);
    }


    public void OnEnter()
    {
        _image.sprite = enterImage;
        text.SetActive(true);
    }

    public void OnExit()
    {
        _image.sprite = defaultImage;
        text.SetActive(false);
    }
}
