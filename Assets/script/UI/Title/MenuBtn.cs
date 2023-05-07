using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour
{
    public Sprite open;
    public Sprite close;

    public GameObject Menu;
    public GameObject GameQuit;
    public AudioClip main;
    public GameObject OptionPanel;

    void Start()
    {
        Menu.GetComponent<Image>().sprite = close;
    }

    public void MenuClick()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        if (this.GetComponent<Image>().sprite == close)
        {
            Menu.GetComponent<Image>().sprite = open;
            Menu.transform.GetChild(0).gameObject.SetActive(true);
            Menu.transform.GetChild(1).gameObject.SetActive(true);
            Scene scene = SceneManager.GetActiveScene();
            if(scene.name == "Main")
                Menu.transform.GetChild(2).gameObject.SetActive(true);
        }

        else if (Menu.GetComponent<Image>().sprite == open)
        {
            Menu.GetComponent<Image>().sprite = close;
            Menu.transform.GetChild(0).gameObject.SetActive(false);
            Menu.transform.GetChild(1).gameObject.SetActive(false);
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Main")
                Menu.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
    public void OptionBtnClicked()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        OptionPanel.SetActive(true);
    }

    public void OptionCloseBtnClicked()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        OptionPanel.SetActive(false);
    }

    public void HomeIconClick()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameQuit.gameObject.SetActive(true);
    }
    public void QuitYes()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        SceneManager.LoadScene("Title");
    }
    public void QuitNo()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameQuit.gameObject.SetActive(false);
    }
    public void ShowUnsupportedMessage()
    {
        GameObject.Find("popup").transform.GetChild(2).gameObject.SetActive(true);
        Invoke("CloseUnsupportedMessage", 2f);
    }
    public void CloseUnsupportedMessage()
    {
        GameObject.Find("popup").transform.GetChild(2).gameObject.SetActive(false);
    }
    public void NewsClose()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("click");
        GameObject.Find("Panels").transform.GetChild(3).gameObject.SetActive(true);
        if (GameDataManager.Instance.Day != 1)
        {
            NextDay.FindObjectOfType<NextDay>().NextDayClick();
        }
        Invoke("CloseNews", 2f);
    }

    public void CloseNews()
    {
        GameObject.Find("Panels").transform.GetChild(3).gameObject.SetActive(false);
        GameObject.Find("NewsTime").gameObject.SetActive(false);
        if (GameDataManager.Instance.Day == 1)
        {
            GameObject.Find("Panels").transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void credit()
    {
        GameObject.Find("CreditPanel").transform.GetChild(0).gameObject.SetActive(true);
        Invoke("creditClose", 31f);
    }

    public void creditClose()
    {
        GameObject.Find("CreditPanel").transform.GetChild(0).gameObject.SetActive(false);
    }
    public void ScreenSize()
    {
        GameObject.Find("ScreenSizePanel").transform.GetChild(0).gameObject.SetActive(true);
    }
}
