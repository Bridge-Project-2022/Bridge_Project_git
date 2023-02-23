using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public string[] tutStart = new string[10];
    public string[] tutStore = new string[10];
    public string[] tutBuy = new string[10];
    public string[] tutCreate = new string[10];
    public string[] tutResult = new string[10];

    public void Start()
    {
        tutStart[0] = "안녕"; tutStart[1] = "튜토리얼 시작할게"; tutStart[2] = "이건 세계관"; tutStart[3] = "이건 향료 설명"; tutStart[4] = "이제 상점 눌러봐";
    }

}
