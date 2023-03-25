using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ToolTip
{
    public readonly Enums.MoveButton button;
    public readonly string name;
    
    public ToolTip(Enums.MoveButton button, string name)
    {
        this.name = name;
        this.button = button;
    }
}