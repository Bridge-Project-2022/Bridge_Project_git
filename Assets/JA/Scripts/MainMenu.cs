using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnNewGameClicked()
    {
        GameDataManager.Instance.NewGameStart();
        SceneManager.LoadScene("Main");
    }
    
    public void OnLoadGameClicked()
    {
        GameDataManager.Instance.LoadData();
        SceneManager.LoadScene("Main");
    }
}
