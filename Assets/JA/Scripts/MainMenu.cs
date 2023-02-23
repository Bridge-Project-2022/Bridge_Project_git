using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnNewGameClicked()
    {
        GameDataManager.Instance.NewGameStart();
        SceneManager.LoadScene("Start");
    }
    
    public void OnLoadGameClicked()
    {
        //SceneManager.LoadScene("Main");
        GameDataManager.Instance.LoadData();
    }
}
