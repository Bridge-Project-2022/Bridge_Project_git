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
    public GameObject NewsFadePanel;

    public GameObject RepHandle;

    public GameObject GameQuit;
    public AudioClip main;
    public GameObject OptionPanel;

    void Start()
    {
        Menu.GetComponent<Image>().sprite = close;
    }
    private void Update()
    {
        RepHandle.GetComponent<Image>().SetNativeSize();
    }

    public void MenuClick()
    {
        if (this.GetComponent<Image>().sprite == close)
        {
            Menu.GetComponent<Image>().sprite = open;
            Menu.transform.GetChild(0).gameObject.SetActive(true);
            Menu.transform.GetChild(1).gameObject.SetActive(true);
        }

        else if (Menu.GetComponent<Image>().sprite == open)
        {
            Menu.GetComponent<Image>().sprite = close;
            Menu.transform.GetChild(0).gameObject.SetActive(false);
            Menu.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void OptionBtnClicked()
    {
        OptionPanel.SetActive(true);
    }

    public void OptionCloseBtnClicked()
    {
        OptionPanel.SetActive(false);
    }

    public void HomeIconClick()
    {
        GameQuit.gameObject.SetActive(true);
    }
    public void QuitYes()
    {
        SceneManager.LoadScene("Title");
    }
    public void QuitNo()
    {
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
        NewsFadePanel.SetActive(true);
        if (GameDataManager.Instance.Day != 1)
        {
            NextDay.FindObjectOfType<NextDay>().NextDayClick();
        }
        Invoke("CloseNews", 2f);
    }

    public void CloseNews()
    {
        NewsFadePanel.gameObject.SetActive(false);
        GameObject.Find("NewsTime").gameObject.SetActive(false);
        if (GameDataManager.Instance.Day == 1)
        {
            GameObject.Find("Panels").transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
