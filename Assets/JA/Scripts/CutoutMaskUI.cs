using UnityEngine;
using UnityEngine.UI;

public class CutoutMaskUI : Image
{
    public override Material materialForRendering
    {
        get
        {
            Material material = new Material(base.materialForRendering);
            material.SetInt("_StencilComp", (int)UnityEngine.Rendering.CompareFunction.NotEqual);
            return material;
        }
    }
}
