using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenuBtns : MonoBehaviour
{
    [SerializeField]
    private GameObject OptionMenu;

    [SerializeField]
    private GameObject OptionPanel;

    private bool IsOptionMenuBtnActive = false;

    public void OptionMenuBtnClicked()
    {
        if(IsOptionMenuBtnActive)
        {
            OptionMenu.SetActive(false);
            IsOptionMenuBtnActive = false;
        }
        else
        {
            OptionMenu.SetActive(true);
            OptionPanel.SetActive(false);
            IsOptionMenuBtnActive = true;
        }
    }

    public void OptionBtnClicked()
    {
        OptionPanel.SetActive(true);
    }

    public void HomeBtnClicked()
    {
        SceneManager.LoadScene("Title");
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
