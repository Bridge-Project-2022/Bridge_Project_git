using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartSceneManager : MonoBehaviour
{
    public VideoPlayer vid;
    public void SkipBtnClicked()
    {
        SceneManager.LoadScene("Main");
    }
    public void Start()
    {
        vid.loopPointReached += CheckOver;
    }

    public void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Main");
    }
}
