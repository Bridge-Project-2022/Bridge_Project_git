using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public bool gameStart = false;
    public GameObject unsupportedTxt;
    public void OnNewGameClicked()
    {
        gameStart = true;
        GameDataManager.Instance.NewGameStart();
        SceneManager.LoadScene("Start");
    }
    
    public void OnLoadGameClicked()
    {
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
        unsupportedTxt.SetActive(true);
        unsupportedTxt.GetComponent<TextMeshProUGUI>().text = "현재 지원되지 않는 기능입니다.";
        Invoke("unsupported", 2f);
    }
}
