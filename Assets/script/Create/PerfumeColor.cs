using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PerfumeColor : MonoBehaviour
{
    public bool isDistillFin = false;
    public bool isPressFin = false;
    public bool isCoolFin = false;
    public int FinishCnt = 0;

    public GameObject Liquid1;
    public GameObject Liquid2_1;
    public GameObject Liquid2_2;
    public GameObject Liquid3_1;
    public GameObject Liquid3_2;

    // HEX COLOR SYSTEM WOOT 
    public static Color hexToColor(string hex)
    {
        hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
        byte a = 255;//assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        //Only use alpha if the string has enough characters
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        }
        return new Color32(r, g, b, a);
    }

    public void PerfumeChoice(string name)
    {
        if (FinishCnt == 1)
        {
            Color color1 = Liquid1.GetComponent<Image>().color;
            color1.a = 0.5f;
            Liquid1.GetComponent<Image>().color = color1;
            
            Color color1_2 = Liquid1.transform.GetChild(0).GetComponent<Image>().color;
            color1_2.a = 0.5f;
            Liquid1.transform.GetChild(0).GetComponent<Image>().color = color1_2;

            Color color2 = Liquid2_1.GetComponent<Image>().color;
            color2.a = 0f;
            Liquid2_1.GetComponent<Image>().color = color2;

            Color color2_1 = Liquid2_1.transform.GetChild(0).GetComponent<Image>().color;
            color2_1.a = 0f;
            Liquid2_1.transform.GetChild(0).GetComponent<Image>().color = color2_1;

            Color color3 = Liquid2_2.GetComponent<Image>().color;
            color3.a = 0f;
            Liquid2_2.GetComponent<Image>().color = color3;

            Color color3_1 = Liquid2_2.transform.GetChild(0).GetComponent<Image>().color;
            color3_1.a = 0f;
            Liquid2_2.transform.GetChild(0).GetComponent<Image>().color = color3_1;

            Color color4 = Liquid3_1.GetComponent<Image>().color;
            color4.a = 0f;
            Liquid3_1.GetComponent<Image>().color = color4;

            Color color4_1 = Liquid3_1.transform.GetChild(0).GetComponent<Image>().color;
            color4_1.a = 0f;
            Liquid3_1.transform.GetChild(0).GetComponent<Image>().color = color4_1;

            Color color5 = Liquid3_2.GetComponent<Image>().color;
            color5.a = 0f;
            Liquid3_2.GetComponent<Image>().color = color5;

            Color color5_1 = Liquid3_2.transform.GetChild(0).GetComponent<Image>().color;
            color5_1.a = 0f;
            Liquid3_2.transform.GetChild(0).GetComponent<Image>().color = color5_1;

            Debug.Log(name);
            if (name == "장소")
            {
                PerfumeMix_1("de7a81");
            }
            else if (name == "사람")
            {
                PerfumeMix_1("b7c44d");
            }
            else if (name == "물건")
            {
                PerfumeMix_1("989895");
            }
            else if (name == "동물")
            {
                PerfumeMix_1("e1a55a");
            }
        }
        if (FinishCnt == 2)
        {
            Color color1 = Liquid1.GetComponent<Image>().color;
            color1.a = 0f;
            Liquid1.GetComponent<Image>().color = color1;

            Color color1_2 = Liquid1.transform.GetChild(0).GetComponent<Image>().color;
            color1_2.a = 0f;
            Liquid1.transform.GetChild(0).GetComponent<Image>().color = color1_2;

            Color color2 = Liquid2_1.GetComponent<Image>().color;
            color2.a = 0.5f;
            Liquid2_1.GetComponent<Image>().color = color2;

            Color color2_1 = Liquid2_1.transform.GetChild(0).GetComponent<Image>().color;
            color2_1.a = 0.5f;
            Liquid2_1.transform.GetChild(0).GetComponent<Image>().color = color2_1;

            Color color3 = Liquid2_2.GetComponent<Image>().color;
            color3.a = 0.5f;
            Liquid2_2.GetComponent<Image>().color = color3;

            Color color3_1 = Liquid2_2.transform.GetChild(0).GetComponent<Image>().color;
            color3_1.a = 0.5f;
            Liquid2_2.transform.GetChild(0).GetComponent<Image>().color = color3_1;

            Color color4 = Liquid3_1.GetComponent<Image>().color;
            color4.a = 0f;
            Liquid3_1.GetComponent<Image>().color = color4;

            Color color4_1 = Liquid3_1.transform.GetChild(0).GetComponent<Image>().color;
            color4_1.a = 0f;
            Liquid3_1.transform.GetChild(0).GetComponent<Image>().color = color4_1;

            Color color5 = Liquid3_2.GetComponent<Image>().color;
            color5.a = 0f;
            Liquid3_2.GetComponent<Image>().color = color5;

            Color color5_1 = Liquid3_2.transform.GetChild(0).GetComponent<Image>().color;
            color5_1.a = 0f;
            Liquid3_2.transform.GetChild(0).GetComponent<Image>().color = color5_1;

            if (name == "연인")
            {
                PerfumeMix_2("f3baa8");
            }
            else if (name == "가족")
            {
                PerfumeMix_2("8d963e");
            }
            else if (name == "반려동물")
            {
                PerfumeMix_2("f3dcb0");
            }
            else if (name == "놀이공원")
            {
                PerfumeMix_2("ab9e7a");
            }
            else if (name == "인형")
            {
                PerfumeMix_2("6987bf");
            }
            else if (name == "여행지")
            {
                PerfumeMix_2("d08553");
            }
            else if (name == "친구")
            {
                PerfumeMix_2("867538");
            }
            else if (name == "장난감")
            {
                PerfumeMix_2("3852f8");
            }
            else if (name == "학교")
            {
                PerfumeMix_2("dc5a54");
            }
            else if (name == "자신")
            {
                PerfumeMix_2("7d1c3d");
            }
            else if (name == "놀이터")
            {
                PerfumeMix_2("f48d56");
            }
        }
        if (FinishCnt == 3)
        {
            Color color1 = Liquid1.GetComponent<Image>().color;
            color1.a = 0f;
            Liquid1.GetComponent<Image>().color = color1;

            Color color1_2 = Liquid1.transform.GetChild(0).GetComponent<Image>().color;
            color1_2.a = 0f;
            Liquid1.transform.GetChild(0).GetComponent<Image>().color = color1_2;

            Color color2 = Liquid2_1.GetComponent<Image>().color;
            color2.a = 0f;
            Liquid2_1.GetComponent<Image>().color = color2;

            Color color2_1 = Liquid2_1.transform.GetChild(0).GetComponent<Image>().color;
            color2_1.a = 0f;
            Liquid2_1.transform.GetChild(0).GetComponent<Image>().color = color2_1;

            Color color3 = Liquid2_2.GetComponent<Image>().color;
            color3.a = 0f;
            Liquid2_2.GetComponent<Image>().color = color3;

            Color color3_1 = Liquid2_2.transform.GetChild(0).GetComponent<Image>().color;
            color3_1.a = 0f;
            Liquid2_2.transform.GetChild(0).GetComponent<Image>().color = color3_1;

            Color color4 = Liquid3_1.GetComponent<Image>().color;
            color4.a = 0.5f;
            Liquid3_1.GetComponent<Image>().color = color4;

            Color color4_1 = Liquid3_1.transform.GetChild(0).GetComponent<Image>().color;
            color4_1.a = 0.5f;
            Liquid3_1.transform.GetChild(0).GetComponent<Image>().color = color4_1;

            Color color5 = Liquid3_2.GetComponent<Image>().color;
            color5.a = 0.5f;
            Liquid3_2.GetComponent<Image>().color = color5;

            Color color5_1 = Liquid3_2.transform.GetChild(0).GetComponent<Image>().color;
            color5_1.a = 0.5f;
            Liquid3_2.transform.GetChild(0).GetComponent<Image>().color = color5_1;
        }
    }
    
    public void PerfumeMix_1(string ColorStr)
    {
        Liquid1.transform.GetChild(0).GetComponent<Image>().color = hexToColor(ColorStr);
        Liquid2_1.transform.GetChild(0).GetComponent<Image>().color = hexToColor(ColorStr);
        Liquid3_1.transform.GetChild(0).GetComponent<Image>().color = hexToColor(ColorStr);
        
        Color color = Liquid1.transform.GetChild(0).GetComponent<Image>().color;
        color.a = 0.5f;
        Liquid1.transform.GetChild(0).GetComponent<Image>().color = color;
    }
    public void PerfumeMix_2(string ColorStr)
    {
        Liquid2_2.transform.GetChild(0).GetComponent<Image>().color = hexToColor(ColorStr);
        Liquid3_2.transform.GetChild(0).GetComponent<Image>().color = hexToColor(ColorStr);

        Color color = Liquid2_1.transform.GetChild(0).GetComponent<Image>().color;
        color.a = 0.5f;
        Liquid2_1.transform.GetChild(0).GetComponent<Image>().color = color;

        Color color2 = Liquid2_2.transform.GetChild(0).GetComponent<Image>().color;
        color2.a = 0.5f;
        Liquid2_2.transform.GetChild(0).GetComponent<Image>().color = color2;
    }
    public void PerfumeReset()
    {
        Color color1 = Liquid1.GetComponent<Image>().color;
        color1.a = 0f;
        Liquid1.GetComponent<Image>().color = color1;

        Color color1_2 = Liquid1.transform.GetChild(0).GetComponent<Image>().color;
        color1_2.a = 0f;
        Liquid1.transform.GetChild(0).GetComponent<Image>().color = color1_2;

        Color color2 = Liquid2_1.GetComponent<Image>().color;
        color2.a = 0f;
        Liquid2_1.GetComponent<Image>().color = color2;

        Color color2_1 = Liquid2_1.transform.GetChild(0).GetComponent<Image>().color;
        color2_1.a = 0f;
        Liquid2_1.transform.GetChild(0).GetComponent<Image>().color = color2_1;

        Color color3 = Liquid2_2.GetComponent<Image>().color;
        color3.a = 0f;
        Liquid2_2.GetComponent<Image>().color = color3;

        Color color3_1 = Liquid2_2.transform.GetChild(0).GetComponent<Image>().color;
        color3_1.a = 0f;
        Liquid2_2.transform.GetChild(0).GetComponent<Image>().color = color3_1;

        Color color4 = Liquid3_1.GetComponent<Image>().color;
        color4.a = 0f;
        Liquid3_1.GetComponent<Image>().color = color4;

        Color color4_1 = Liquid3_1.transform.GetChild(0).GetComponent<Image>().color;
        color4_1.a = 0f;
        Liquid3_1.transform.GetChild(0).GetComponent<Image>().color = color4_1;

        Color color5 = Liquid3_2.GetComponent<Image>().color;
        color5.a = 0f;
        Liquid3_2.GetComponent<Image>().color = color5;

        Color color5_1 = Liquid3_2.transform.GetChild(0).GetComponent<Image>().color;
        color5_1.a = 0f;
        Liquid3_2.transform.GetChild(0).GetComponent<Image>().color = color5_1;
    }
}
