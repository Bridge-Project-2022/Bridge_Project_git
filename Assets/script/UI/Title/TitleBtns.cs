using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleBtns : MonoBehaviour
{
    public GameObject[] TitleBtnList;
    public Button MyBtn;

    [SerializeField]
    private GameObject OptionPanel;
    float btnActiveDuration = 0.5f;

    void Start()
    {
        StartCoroutine(TitleBtnActive());
    }
    public void NewGameBtnClicked()
    {
        SceneManager.LoadScene("TestScene");
        NewSoundManager.instance.StopBGM();
    }

    public void OptionBtnClicked()
    {
        OptionPanel.SetActive(true);
    }

    public void ExitBtnClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
     Application.Quit();
#endif
    }

    public void OptionCloseBtnClicked()
    {
        OptionPanel.SetActive(false);
    }

    public void OnMouseEnter()
    {
        if(this.gameObject.name == "GameStart")
        {
            Debug.Log("s");
        }
    }

    IEnumerator TitleBtnActive()
    {
        foreach (GameObject Btn in TitleBtnList)
        {
            Btn.SetActive(true);
            yield return new WaitForSeconds(btnActiveDuration);
        }
        
        yield return null;
    }

    public void OnMouseExit()
    {
        
    }

    public void OnMouseDown()
    {
        
    }
}
