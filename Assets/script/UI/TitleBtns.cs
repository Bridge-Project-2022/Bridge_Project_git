using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBtns : MonoBehaviour
{
    [SerializeField]
    private GameObject OptionPanel;
    public void NewGameBtnClicked()
    {
        SceneManager.LoadScene("Main");
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
}
