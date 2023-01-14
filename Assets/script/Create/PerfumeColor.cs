using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PerfumeColor : MonoBehaviour
{
    public byte ColorR = 255;
    public byte ColorG = 255;
    public byte ColorB = 255;

    Image Liquid;
    public void PerfumeMix(byte r, byte g, byte b)
    {
        ColorR -= r;
        ColorG -= g;
        ColorB -= b;

        Liquid = this.GetComponent<Image>();
        Color color = Liquid.color;
        color = new Color32(ColorR, ColorG, ColorB, 120);
        Liquid.color = color;
    }

    public void PerfumeReset()
    {
        Color color = Liquid.color;
        color = new Color32(255, 255, 255, 120);
        Liquid.color = color;

        ColorR = 255;
        ColorG = 255;
        ColorB = 255;
    }
}
