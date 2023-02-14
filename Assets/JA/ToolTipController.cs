using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ToolTipController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI proUGUI;
    [SerializeField] private DOTweenAnimation[] animations;

    [SerializeField] private GameObject explanation;

    private string visitAsk = "을(를) 방문하시겠습니끼?";
    private string notVisiteAsk = "아직 방문하지 않은 중요한 장소가 남아 있습니다.";
    private void Start()
    {
        
    }

    public void SetUp(ToolTip tip)
    {
        // 여기서 GameManager에서 변수 불러와 체크
        // 일차에 방문 if (방문 해야하는데 안함)
        // 그럼 수정
        proUGUI.text = default;
        
        string titleText = tip.name + visitAsk;
        proUGUI.text = titleText;

        foreach (var animation in animations)
        {
            animation.DORestart();
        }
    }

    public void RewindTest()
    {

    }

    private void OnEnable()
    {
        explanation.SetActive(false);
    }

    private void OnDisable()
    {
        explanation.SetActive(true);
    }
}
