using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource sfxAudioSource;
    AudioSource bgmAudioSource;
    AudioSource typeAudioSource;

    public AudioClip visit;
    public AudioClip inven;
    public AudioClip money;
    public AudioClip fireon;
    public AudioClip click;
    public AudioClip typing;
    public AudioClip boilHigh;
    public AudioClip boilMiddle;
    public AudioClip boilLow;
    public AudioClip pressDown;
    public AudioClip CoolerTouch;
    public AudioClip DayFinish;
    public AudioClip BuyFail;
    public AudioClip coolPick;
    public AudioClip perfumeTouch;

    public AudioClip news;
    public AudioClip main;
    public AudioClip Lorena1;
    public AudioClip LorenaCutScene;

    public GameObject newsPanel;

    // Start is called before the first frame update
    void Start()
    {
        bgmAudioSource = this.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        sfxAudioSource = this.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        typeAudioSource = this.transform.GetChild(2).gameObject.GetComponent<AudioSource>();
    }
    public void PlaySFX(string action)
    {
        switch (action)
        {
            case "visit":
                sfxAudioSource.clip = visit;
                sfxAudioSource.loop = false;
                break;

            case "inven":
                sfxAudioSource.clip = inven;
                sfxAudioSource.loop = false;
                break;

            case "money":
                sfxAudioSource.clip = money;
                sfxAudioSource.loop = false;
                break;

            case "fireon":
                sfxAudioSource.clip = fireon;
                sfxAudioSource.loop = false;
                break;

            case "click":
                sfxAudioSource.clip = click;
                sfxAudioSource.loop = false;
                break;

            case "boilHigh":
                sfxAudioSource.clip = boilHigh;
                sfxAudioSource.loop = true;
                break;

            case "boilMiddle":
                sfxAudioSource.clip = boilMiddle;
                sfxAudioSource.loop = true;
                break;

            case "boilLow":
                sfxAudioSource.clip = boilLow;
                sfxAudioSource.loop = true;
                break;

            case "pressDown":
                sfxAudioSource.clip = pressDown;
                sfxAudioSource.loop = false;
                break;

            case "coolerTouch":
                sfxAudioSource.clip = CoolerTouch;
                sfxAudioSource.loop = false;
                break;

            case "DayFinish":
                sfxAudioSource.clip = DayFinish;
                sfxAudioSource.loop = false;
                break;

            case "BuyFail":
                sfxAudioSource.clip = BuyFail;
                sfxAudioSource.loop = false;
                break;

            case "coolPick":
                sfxAudioSource.clip = coolPick;
                sfxAudioSource.loop = false;
                break;

            case "perfumeTouch":
                sfxAudioSource.clip = perfumeTouch;
                sfxAudioSource.loop = false;
                break;
        }
        sfxAudioSource.Play();
    }

    public void PlayBGM(string action)
    {
        switch (action)
        {
            case "news":
                bgmAudioSource.clip = news;
                bgmAudioSource.volume = 1f;
                break;

            case "main":
                bgmAudioSource.clip = main;
                bgmAudioSource.volume = 0.7f;
                break;

            case "Lorena1":
                bgmAudioSource.clip = Lorena1;
                bgmAudioSource.volume = 1f;
                break;

            case "LorenaCutScene":
                bgmAudioSource.clip = LorenaCutScene;
                bgmAudioSource.volume = 1f;
                break;
        }
        bgmAudioSource.Play();
    }

    public void playTyping(string action)
    {
        switch (action)
        {
            case "typing":
                typeAudioSource.clip = typing;
                typeAudioSource.loop = true;
                break;
        }
        typeAudioSource.Play();
    }

    public void SFXStop()
    {
        sfxAudioSource.Stop();
    }

    public void typeStop()
    {
        typeAudioSource.Stop();
    }
}
