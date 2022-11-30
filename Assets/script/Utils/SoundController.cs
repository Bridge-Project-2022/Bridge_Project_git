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

    bool isBGMOn = false;
    bool isSFXOn = false;

    public void SetBGMVolume(float volume)
    {
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
            BGMSource.gameObject.SetActive(false);

            isBGMOn = true;
        }

        else if (isBGMOn == true)
        {
            GameObject.Find("BgmVolume").gameObject.GetComponent<Image>().sprite = BGMOnImg;

            BGMSlider.gameObject.SetActive(true);
            BGMSource.gameObject.SetActive(true);

            isBGMOn = false;
        }
    }
    public void SFXOnOff()
    {
        if (isSFXOn == false)
        {
            GameObject.Find("SfxVolume").gameObject.GetComponent<Image>().sprite = SFXOffImg;

            SFXSlider.gameObject.SetActive(false);
            SFXSource.gameObject.SetActive(false);
            TypingSource.gameObject.SetActive(false);

            SFXSource.clip = null;
            TypingSource.clip = null;

            isSFXOn = true;
        }

        else if (isSFXOn == true)
        {
            GameObject.Find("SfxVolume").gameObject.GetComponent<Image>().sprite = SFXOnImg;

            SFXSlider.gameObject.SetActive(true);
            SFXSource.gameObject.SetActive(true);
            TypingSource.gameObject.SetActive(true);

            isSFXOn = false;
        }
    }
}
