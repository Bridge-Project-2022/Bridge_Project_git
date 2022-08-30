using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class NewSoundManager : MonoBehaviour
{
    public static NewSoundManager instance;

    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;

    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;

    public float sfxVolume = 1.0f;
    public float bgmVolume = 1.0f;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        PlayBGM("Title");
    }

    public void PlayBGM(string bgmName)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (bgmName == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
            }
        }
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    public void PlaySFX(string sfxName)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (sfxName == sfx[i].name)
            {
                for (int j = 0; j < sfxPlayer.Length; j++)
                {
                    if (!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].clip = sfx[i].clip;
                        sfxPlayer[j].Play();
                        return;
                    }
                }
            }
        }
    }

    public void SetBGMVolume(float volume)
    {
        bgmPlayer.volume = volume;
    }

    public void SetSfxVolume(float volume)
    {
        for (int i = 0; i < sfxPlayer.Length; i++)
        {
            sfxPlayer[i].volume = volume;
        }
    }
}