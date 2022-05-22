using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource sfxAudioSource;
    AudioSource typeAudioSource;

    public AudioClip visit;
    public AudioClip inven;
    public AudioClip money;
    public AudioClip fireon;
    public AudioClip click;
    public AudioClip typing;
    public AudioClip boiling;

    // Start is called before the first frame update
    void Start()
    {
        sfxAudioSource = this.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        typeAudioSource = this.transform.GetChild(2).gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
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

            case "boiling":
                sfxAudioSource.clip = boiling;
                sfxAudioSource.loop = true;
                break;
        }
        sfxAudioSource.Play();
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
