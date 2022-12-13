using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
       GameDataManager.Instance.NewGameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
