using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingSceneManager : MonoBehaviour
{
    public string SceneName;

    private float time;
    public TextMeshProUGUI Loading;
    public TextMeshProUGUI LoadingRandomText;
    public string[] LoadingText = new string[11];
    void Start()
    {
        LoadingRandomText.text = LoadingText[Random.Range(0,11)];
        StartCoroutine(LoadAsynSceneCoroutine());
    }

    IEnumerator LoadAsynSceneCoroutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            time = +Time.time;
            Loading.text = ((int)time * 10).ToString() + " / 100";

            if (time > 10)
                operation.allowSceneActivation = true;

            yield return null;
        }
    }

    public void clickLoadingText()
    {
        LoadingRandomText.text = LoadingText[Random.Range(0, 11)];
    }
}
