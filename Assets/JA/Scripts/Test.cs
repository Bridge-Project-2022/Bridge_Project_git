using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
       GameDataManager.Instance.NewGameStart();
       GameDataManager.Instance.Money = GameDataManager.Instance.Money - 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
