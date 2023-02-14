
using System.Collections.Generic;
using UnityEngine;

public class ToolTipBuild : MonoBehaviour
{
    [Header("Set")]
    [SerializeField] private ToolTip toolTip;
    
    [Header("ToolTipController")]
    [SerializeField] private ToolTipController tipController;
    public void SetUp()
    {
        tipController.gameObject.SetActive(true);
        
        tipController.SetUp(toolTip);
    }
}
