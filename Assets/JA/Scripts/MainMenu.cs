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
        GameObject.Find("GameDataManager(singleton)").GetComponent<GameDataManager>().LoadData();
    }
}
