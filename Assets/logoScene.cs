using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class logoScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("titleMove", 4.25f);
    }

    public void titleMove()
    {
        SceneManager.LoadScene("Title");
    }
}
