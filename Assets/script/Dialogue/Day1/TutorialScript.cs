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

    public void Update()
    {
        tutStart[0] = "안녕"; tutStart[1] = "튜토리얼 시작할게"; tutStart[2] = "이건 세계관"; tutStart[3] = "이건 향료 설명"; tutStart[4] = "이제 상점 설명할게";

        tutStore[0] = "상점에서 물건 살 수 있어"; tutStore[1] = "스킵하쉴?"; tutStore[2] = "베이스 노트 살 수 있어"; tutStore[3] = "미들 클릭해봐"; tutStore[4] = "미들 살 수 있어"; tutStore[5] = "탑 클릭해봐"; tutStore[6] = "탑 살 수 있어";
    }

}
