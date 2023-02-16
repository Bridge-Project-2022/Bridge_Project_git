using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaceVisibilityController : MonoBehaviour
{
    [Header("ObjectImage")]
    [SerializeField] private Image objectImage;
    [SerializeField] private Sprite defaultObjectImage;
    [SerializeField] private Sprite enterObjectImage;
    
    [Header("NoticeImage")]
    [SerializeField] private Image noticeImage;
    [SerializeField] private Sprite defaultNoticeImage;
    [SerializeField] private Sprite enterNoticeImage;
    [SerializeField] private Sprite defaultSpecialNoticeImage;
    [SerializeField] private Sprite enterSpecialNoticeImage;
    
    [Header("Notice")]
    [SerializeField] private GameObject notice;
    
    [Header("Effect")]
    [SerializeField] private GameObject text;
    
    private bool _isVisitable;
    private bool _isSpecial;

    private void Start()
    {
        text.SetActive(false);
    }
    
    public void OnEnter()
    {
        objectImage.sprite = enterObjectImage;
        if (_isSpecial)
        {
            noticeImage.sprite = enterSpecialNoticeImage;
        }
        else
        {
            noticeImage.sprite = enterNoticeImage;
        }

        text.SetActive(true);
    }

    public void OnExit()
    {
        objectImage.sprite = defaultObjectImage;
        if (_isSpecial)
        {
            noticeImage.sprite = defaultSpecialNoticeImage;
        }
        else
        {
            noticeImage.sprite = defaultNoticeImage;
        }

        text.SetActive(false);
    }

    public void SetUp(bool isVisitable, bool isSpecial)
    {
        this._isVisitable = isVisitable;
        this._isSpecial = isSpecial;
        
        objectImage.sprite = defaultObjectImage;
        noticeImage.sprite = defaultNoticeImage;
        
        if (!_isVisitable)
        {
            this.GetComponent<EventTrigger>().enabled = false;
            notice.SetActive(false);
            return;
        }
        else
        {
            this.GetComponent<EventTrigger>().enabled = true;
            notice.SetActive(true);
        }
        
        if (_isSpecial)
        {
            noticeImage.sprite = defaultSpecialNoticeImage;
        }
    }
}
