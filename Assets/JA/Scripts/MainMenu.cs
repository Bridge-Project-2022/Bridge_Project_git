using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public bool gameStart = false;
    public GameObject unsupportedTxt;
    public AudioClip Click;
    public void OnNewGameClicked()
    {
        GameObject.Find("SFX").GetComponent<AudioSource>().clip = Click;
        GameObject.Find("SFX").GetComponent<AudioSource>().Play();
        gameStart = true;
        GameDataManager.Instance.NewGameStart();
        SceneManager.LoadScene("Start");
    }
    
    public void OnLoadGameClicked()
    {
        GameObject.Find("SFX").GetComponent<AudioSource>().clip = Click;
        GameObject.Find("SFX").GetComponent<AudioSource>().Play();
        if (GameDataManager.Instance.Day > 1)
        {
            GameDataManager.Instance.LoadData();
        }
        else
        {
            unsupportedTxt.SetActive(true);
            unsupportedTxt.GetComponent<TextMeshProUGUI>().text = "게임을 이어할 데이터가 없습니다.";
            Invoke("unsupported", 2f);
        }

    }

    void unsupported()
    {
        unsupportedTxt.SetActive(false);
    }

    public void credit()
    {
        GameObject.Find("SFX").GetComponent<AudioSource>().clip = Click;
        GameObject.Find("SFX").GetComponent<AudioSource>().Play();
        GameObject.Find("CreditPanel").transform.GetChild(0).gameObject.SetActive(true);
        Invoke("creditClose", 31f);
    }

    public void ScreenSize()
    {
        GameObject.Find("SFX").GetComponent<AudioSource>().clip = Click;
        GameObject.Find("SFX").GetComponent<AudioSource>().Play();
        GameObject.Find("ScreenSizePanel").transform.GetChild(0).gameObject.SetActive(true);
    }
    public void creditClose()
    {
        GameObject.Find("SFX").GetComponent<AudioSource>().clip = Click;
        GameObject.Find("SFX").GetComponent<AudioSource>().Play();
        GameObject.Find("CreditPanel").transform.GetChild(0).gameObject.SetActive(false);
    }
}
