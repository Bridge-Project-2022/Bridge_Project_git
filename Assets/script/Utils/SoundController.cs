using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioSource BGMSource;
    public AudioSource SFXSource;
    public AudioSource TypingSource;

    public Sprite BGMOnImg;
    public Sprite BGMOffImg;
    public Sprite SFXOnImg;
    public Sprite SFXOffImg;

    public GameObject BGMSlider;
    public GameObject SFXSlider;

    public bool isBGMOn = true;
    public bool isSFXOn = true;

    public void SetBGMVolume(float volume)
    {
        Debug.Log(volume);
        BGMSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        SFXSource.volume = volume;
    }

    public void SetTypeVolume(float volume)
    {
        TypingSource.volume = volume;
    }

    public void BGMOnOff()
    {
        if (isBGMOn == false)
        {
            GameObject.Find("BgmVolume").gameObject.GetComponent<Image>().sprite = BGMOffImg;

            BGMSlider.gameObject.SetActive(false);
            BGMSource.volume = 0.0f;

            isBGMOn = true;
        }

        else if (isBGMOn == true)
        {
            GameObject.Find("BgmVolume").gameObject.GetComponent<Image>().sprite = BGMOnImg;

            BGMSlider.gameObject.SetActive(true);
            BGMSource.volume = 1f;

            isBGMOn = false;
        }
    }
    public void SFXOnOff()
    {
        if (isSFXOn == false)
        {
            GameObject.Find("SfxVolume").gameObject.GetComponent<Image>().sprite = SFXOffImg;

            SFXSource.volume = 0.0f;
            TypingSource.volume = 0.0f;

            isSFXOn = true;
        }

        else if (isSFXOn == true)
        {
            GameObject.Find("SfxVolume").gameObject.GetComponent<Image>().sprite = SFXOnImg;

            SFXSource.volume = 1.0f;
            TypingSource.volume = 1.0f;

            isSFXOn = false;
        }
    }
}
