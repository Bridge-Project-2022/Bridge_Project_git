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
    // Start is called before the first frame update
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
            //Menu.transform.GetChild(2).gameObject.SetActive(true);
            //Menu.transform.GetChild(3).gameObject.SetActive(true);

            /*if (GameObject.Find("SoundManager").GetComponent<SoundController>().isBGMOn == true)
            {
                GameObject.Find("SoundSlider").transform.GetChild(0).gameObject.SetActive(true);
            }

            else if (GameObject.Find("SoundManager").GetComponent<SoundController>().isBGMOn == false)
            {
                GameObject.Find("SoundSlider").transform.GetChild(0).gameObject.SetActive(false);
            }

            if (GameObject.Find("SoundManager").GetComponent<SoundController>().isSFXOn == true)
            {
                GameObject.Find("SoundSlider").transform.GetChild(1).gameObject.SetActive(true);
            }

            else if (GameObject.Find("SoundManager").GetComponent<SoundController>().isSFXOn == false)
            {
                GameObject.Find("SoundSlider").transform.GetChild(1).gameObject.SetActive(false);
            }*/
        }

        else if (Menu.GetComponent<Image>().sprite == open)
        {
            Menu.GetComponent<Image>().sprite = close;
            Menu.transform.GetChild(0).gameObject.SetActive(false);
            Menu.transform.GetChild(1).gameObject.SetActive(false);
            //Menu.transform.GetChild(2).gameObject.SetActive(false);
            //Menu.transform.GetChild(3).gameObject.SetActive(false);
           //GameObject.Find("SoundSlider").transform.GetChild(0).gameObject.SetActive(false);
           //GameObject.Find("SoundSlider").transform.GetChild(1).gameObject.SetActive(false);
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
        NewsFadePanel.SetActive(true);
        Invoke("CloseNews", 2f);
        GameObject.Find("BGM").GetComponent<AudioSource>().clip = main;
        GameObject.Find("BGM").GetComponent<AudioSource>().Play();
    }
    /*IEnumerator FadeIn()
    {
        for (int i = 0; i < 10; i++)
        {
            float f = i / 10.0f;
            Color c = new Color(0, 0, 0, 255);
            c.a = f;
            FadePannel.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }*/

    public void CloseNews()
    {
        NewsFadePanel.gameObject.SetActive(false);
        GameObject.Find("NewsTime").gameObject.SetActive(false);
    }
}
