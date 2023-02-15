
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Place : MonoBehaviour
{
    [Header("Set")] 
    [SerializeField] private Enums.MoveButton moveButton;
    [SerializeField] private string name;
    [SerializeField] private List<int> visitableDay;
    [SerializeField] private List<int> specialDay;
    
    private ToolTip _toolTip;
    private bool _isVisitable;
    private bool _isSpecial;
    
    public bool IsVisitable { get { return _isVisitable;} }
    public bool IsSpecial { get { return _isSpecial;} }

    [Header("PlaceVisibilityController")]
    [SerializeField] private PlaceVisibilityController placeVisibilityController;
    
    [Header("ToolTipController")]
    [SerializeField] private ToolTipController toolTipController;

    private void Awake()
    {
        _toolTip = new ToolTip(moveButton, name);
        _isVisitable = false;
        _isSpecial = false;

        foreach (var day in visitableDay)
        {
            if (GameDataManager.Instance.Day == day)
            {
                _isVisitable = true;
            }
        }
        
        foreach (var day in specialDay)
        {
            if (GameDataManager.Instance.Day == day)
            {
                _isSpecial = true;
            }
        }

        placeVisibilityController.SetUp(_isVisitable, _isSpecial);
    }

    public void TryVisitPlace(Enums.MoveButton placeType)
    {
        if (placeType == _toolTip.button)
        {
            _isVisitable = false;
            _isSpecial = false;
            placeVisibilityController.SetUp(_isVisitable, _isSpecial);
        }
    }
    
    public void SetToolTip()
    {
        if (_toolTip.button == Enums.MoveButton.RootOfReadButton)
        {
            // 씬전환
        }

        toolTipController.SetUp(_toolTip);
        toolTipController.gameObject.SetActive(true);
    }
}
