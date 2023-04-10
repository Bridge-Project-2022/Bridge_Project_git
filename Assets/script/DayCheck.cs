using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayCheck : MonoBehaviour
{
    public GameObject DeclareBtn;
    public void A_Start_Check()
    {
        if (GameDataManager.Instance.Day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().A_Start();
        }
        else if (GameDataManager.Instance.Day == 2)
        {
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().A_Start();
        }
        else if (GameDataManager.Instance.Day == 3)
        {
            GameObject.Find("Trigger").GetComponent<ThirdDialogueRandom>().A_Start();
            Invoke("DeclareBtnShow", 0.1f);
        }
        else if (GameDataManager.Instance.Day == 4)
        {
            GameObject.Find("Trigger").GetComponent<FourthDialogueRandom>().A_Start();
            Invoke("DeclareBtnShow", 0.1f);
        }
        else if (GameDataManager.Instance.Day == 5)
        {
            GameObject.Find("Trigger").GetComponent<FifthDialogueRandom>().A_Start();
            Invoke("DeclareBtnShow", 0.1f);
        }
        else if (GameDataManager.Instance.Day == 6)
        {
            GameObject.Find("Trigger").GetComponent<SixthDialogueRandom>().A_Start();
            Invoke("DeclareBtnShow", 0.1f);
        }
        else if (GameDataManager.Instance.Day == 7)
        {
            GameObject.Find("Trigger").GetComponent<SeventhDialogueRandom>().A_Start();
            Invoke("DeclareBtnShow", 0.1f);
        }
    }
    public void DeclareBtnShow()
    {
        DeclareBtn.gameObject.SetActive(true);
    }
    public void C1_Check()
    {
        if (GameDataManager.Instance.Day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().C_1_Start();
        }
        else if (GameDataManager.Instance.Day == 2)
        {
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().C_1_Start();
        }
        else if (GameDataManager.Instance.Day == 3)
        {
            if (GameObject.Find("DialogueScript3").GetComponent<ThirdDialogueScript>().Customer_ID[0] == 12)
                CriminalSystem.FindObjectOfType<CriminalSystem>().isCriminalSell = true;
            GameObject.Find("Trigger").GetComponent<ThirdDialogueRandom>().C_1_Start();
        }
        else if (GameDataManager.Instance.Day == 4)
        {
            if (GameObject.Find("DialogueScript3").GetComponent<ThirdDialogueScript>().Customer_ID[0] == 21)
                CriminalSystem.FindObjectOfType<CriminalSystem>().isCriminalSell = true;
            GameObject.Find("Trigger").GetComponent<FourthDialogueRandom>().C_1_Start();
        }
        else if (GameDataManager.Instance.Day == 5)
        {
            if (GameObject.Find("DialogueScript3").GetComponent<ThirdDialogueScript>().Customer_ID[0] == 26)
                CriminalSystem.FindObjectOfType<CriminalSystem>().isCriminalSell = true;
            GameObject.Find("Trigger").GetComponent<FifthDialogueRandom>().C_1_Start();
        }
        else if (GameDataManager.Instance.Day == 6)
        {
            GameObject.Find("Trigger").GetComponent<SixthDialogueRandom>().C_1_Start();
        }
        else if (GameDataManager.Instance.Day == 7)
        {
            GameObject.Find("Trigger").GetComponent<SeventhDialogueRandom>().C_1_Start();
        }
    }

    public void C2_Check()
    {

        if (GameDataManager.Instance.Day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().C_2_Start();
        }
        else if (GameDataManager.Instance.Day == 2)
        {
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().C_2_Start();
        }
        else if (GameDataManager.Instance.Day == 3)
        {
            GameObject.Find("Trigger").GetComponent<ThirdDialogueRandom>().C_2_Start();
        }
        else if (GameDataManager.Instance.Day == 4)
        {
            GameObject.Find("Trigger").GetComponent<FourthDialogueRandom>().C_2_Start();
        }
        else if (GameDataManager.Instance.Day == 5)
        {
            GameObject.Find("Trigger").GetComponent<FifthDialogueRandom>().C_2_Start();
        }
        else if (GameDataManager.Instance.Day == 6)
        {
            GameObject.Find("Trigger").GetComponent<SixthDialogueRandom>().C_2_Start();
        }
        else if (GameDataManager.Instance.Day == 7)
        {
            GameObject.Find("Trigger").GetComponent<SeventhDialogueRandom>().C_2_Start();
        }
        TotalScore.FindObjectOfType<TotalScore>().gameOverCheck();
    }

    public void ND_Check()
    {
        if (GameDataManager.Instance.Day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().NextDialogue();
        }
        else if (GameDataManager.Instance.Day == 2)
        {
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().NextDialogue();
        }
        else if (GameDataManager.Instance.Day == 3)
        {
            GameObject.Find("Trigger").GetComponent<ThirdDialogueRandom>().NextDialogue();
        }
        else if (GameDataManager.Instance.Day == 4)
        {
            GameObject.Find("Trigger").GetComponent<FourthDialogueRandom>().NextDialogue();
        }
        else if (GameDataManager.Instance.Day == 5)
        {
            GameObject.Find("Trigger").GetComponent<FifthDialogueRandom>().NextDialogue();
        }
        else if (GameDataManager.Instance.Day == 6)
        {
            GameObject.Find("Trigger").GetComponent<SixthDialogueRandom>().NextDialogue();
        }
        else if (GameDataManager.Instance.Day == 7)
        {
            GameObject.Find("Trigger").GetComponent<SeventhDialogueRandom>().NextDialogue();
        }
    }
    public void E1_Check()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("money");
        if (GameDataManager.Instance.Day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().E_1_Start();
        }
        else if (GameDataManager.Instance.Day == 2)
        {
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().E_1_Start();
        }
        else if (GameDataManager.Instance.Day == 3)
        {
            GameObject.Find("Trigger").GetComponent<ThirdDialogueRandom>().E_1_Start();
        }
        else if (GameDataManager.Instance.Day == 4)
        {
            GameObject.Find("Trigger").GetComponent<FourthDialogueRandom>().E_1_Start();
        }
        else if (GameDataManager.Instance.Day == 5)
        {
            GameObject.Find("Trigger").GetComponent<FifthDialogueRandom>().E_1_Start();
        }
        else if (GameDataManager.Instance.Day == 6)
        {
            GameObject.Find("Trigger").GetComponent<SixthDialogueRandom>().E_1_Start();
        }
        else if (GameDataManager.Instance.Day == 7)
        {
            GameObject.Find("Trigger").GetComponent<SeventhDialogueRandom>().E_1_Start();
        }
    }

    public void F2_Check()
    {
        if (GameDataManager.Instance.Day == 1)
        {
            GameObject.Find("Trigger").GetComponent<DialogueRandom>().E_1_Start();
        }
        else if (GameDataManager.Instance.Day == 2)
        {
            GameObject.Find("Trigger").GetComponent<SecondDialogueRandom>().E_1_Start();
        }
        else if (GameDataManager.Instance.Day == 3)
        {
            GameObject.Find("Trigger").GetComponent<ThirdDialogueRandom>().E_1_Start();
        }
        else if (GameDataManager.Instance.Day == 4)
        {
            GameObject.Find("Trigger").GetComponent<FourthDialogueRandom>().E_1_Start();
        }
        else if (GameDataManager.Instance.Day == 5)
        {
            GameObject.Find("Trigger").GetComponent<FifthDialogueRandom>().E_1_Start();
        }
        else if (GameDataManager.Instance.Day == 6)
        {
            GameObject.Find("Trigger").GetComponent<SixthDialogueRandom>().E_1_Start();
        }
        else if (GameDataManager.Instance.Day == 7)
        {
            GameObject.Find("Trigger").GetComponent<SeventhDialogueRandom>().E_1_Start();
        }
    }
    public void YesBold()
    {
        GameObject.Find("Dialogue").transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 40;
    }
    public void YesRegular()
    {
        GameObject.Find("Dialogue").transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 30;
    }
    public void NoBold()
    {
        GameObject.Find("Dialogue").transform.GetChild(5).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 35;
    }
    public void NoRegular()
    {
        GameObject.Find("Dialogue").transform.GetChild(5).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 30;
    }
}
