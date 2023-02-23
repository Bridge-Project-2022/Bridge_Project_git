using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI TutCustomerDialogue;
    public TextMeshProUGUI TutDialogue;
    public GameObject SkipSelect;
    public bool isDialogueEnd = false;

    void Start()
    {
        
    }

    public void StartDialogue()//향료 아저씨 대사, 세계관 및 향료 소개, 상점 클릭
    { 
        
    }

    public void StoreDialogue()//향료 노트 설명. 스킵 여부 묻기 => 예 : 다음 넘어감 / 아니오 : 베이스 설명 & 미들탭 하이라이팅, 미들 설명 & 탑탭 하이라이팅, 탑 설명 & 베이스탭 클릭유도 & 첫번째 향료 선택 및 구매 / 일괄구매 설명
    {

    }

    public void BuyDialogue() // 향료 구매 유도, 완료 여부 확인 -> 완료 시 상점 끄기, 손님 시스템 설명, 수락 / 거절 설명 및 클릭 유도, 향수 어떻게 고르는지 설명
    { 
    
    }

    public void CreateDialogue()//제작 화면 넘어감. 스킵 여부 묻기 => 예 : 보상으로 넘어감 / 아니오 : 인벤 클릭 유도, 베이스 선택 유도, 증류기 선택 유도, 증류기 설명, 증류 성공 할 때 까지 반복, 실패 시 재도전 대사, 
                                // 미들 선택 유도, 압착기 선택 유도, 압착기 설명, 압착 성공할 때 까지 반복, 실패 시 재도전 대사, 
                                // 탑 선택 유도, 냉침기 선택 유도, 냉침기 설명, 냉침 성공할 때 까지 반복, 실패 시 재도전 대사
                                // 제작 화면 넘김, 완성 향수 하이라이팅 및 대사, 클릭 유도
    { 
        
    }

    public void ResultDialogue()//향수 보상, 평판, 이동맵 설명 이후 끝, 일반 일과로 넘어감
    { 
        
    }
}
