using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TextEffect : BaseMeshEffect
{
    Text txt;

    public Gradient myGradient;

    float gradientWaveTime;

    protected override void Start()
    {
        txt = GetComponent<Text>();
    }

    private void Update()
    {
        gradientWaveTime += Time.deltaTime;
        txt.FontTextureChanged();
    }
    public override void ModifyMesh(VertexHelper vh)
    {
        List<UIVertex> vertices = new List<UIVertex>();
        vh.GetUIVertexStream(vertices);


        float min = vertices.Min(t => t.position.x);
        float max = vertices.Max(t => t.position.x);

        for (int i = 0; i < vertices.Count; i++)
        {
            var v = vertices[i];

            float curXNormalized = Mathf.InverseLerp(min, max, v.position.x);
            curXNormalized = Mathf.PingPong(curXNormalized + gradientWaveTime, 1f);
            Color c = myGradient.Evaluate(curXNormalized);

            v.color = new Color(c.r, c.g, c.b, 1);
            vertices[i] = v;
        }

        vh.Clear();
        vh.AddUIVertexTriangleStream(vertices);
    }
}
