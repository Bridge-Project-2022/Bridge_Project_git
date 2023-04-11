using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLoad : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;

    void Start()
    {
        bgmSlider.value = GameDataManager.Instance.BGM;
        sfxSlider.value = GameDataManager.Instance.SFX;
    }
}
