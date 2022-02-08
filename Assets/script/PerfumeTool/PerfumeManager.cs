using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfumeManager : MonoBehaviour
{
    public GameObject Distiller;
    public void OnDistillerBtnClick()
    {
        Distiller.SetActive(true);
    }
}
