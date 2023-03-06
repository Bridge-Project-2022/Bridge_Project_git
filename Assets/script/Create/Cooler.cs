using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooler : MonoBehaviour
{
    public GameObject CoolerDetail;

    public ItemProperty ClickedItem;

    public GameObject CoolerOne;//냉침 아이템 1
    public GameObject CoolerTwo;// 냉침 아이템 2
    public GameObject CoolerThree;// 냉침 아이템 3

    public GameObject Particle1;
    public GameObject Particle2;
    public GameObject Particle3;

    public GameObject topInvenSlots;

    public string TopItemName;//손님이 요구하는 탑 향료 이름

    public int ResultCount = 0;
    public int goodCount;

    public Sprite[] ItemSprites = new Sprite[5];
    public Sprite[] ItemBurnSprites = new Sprite[1];//탄 아이템 이미지 배열

    public GameObject Receipt;
    public bool isTopRight = false;
    public void Start()
    {
        goodCount = 0;
    }
    public void CoolerOn(ItemProperty item)
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == true)
        {
            this.gameObject.GetComponent<Button>().interactable = true;//냉침기 버튼 클릭 가능해짐.
            ClickedItem = item;
            Color color = CoolerOne.gameObject.GetComponent<Image>().color;
            color.a = 255;
            CoolerOne.gameObject.GetComponent<Image>().color = color;//아이템 제거

            Color color2 = CoolerTwo.gameObject.GetComponent<Image>().color;
            color2.a = 255;
            CoolerTwo.gameObject.GetComponent<Image>().color = color2;//아이템 제거

            Color color3 = CoolerThree.gameObject.GetComponent<Image>().color;
            color3.a = 255;
            CoolerThree.gameObject.GetComponent<Image>().color = color3;//아이템 제거
            if (ClickedItem.name == "기쁨")
            {
                Debug.Log("튜토리얼 탑 향료 맞음");
                isTopRight = true;
                Tutorial.FindObjectOfType<Tutorial>().NextTutDialogue();
            }
            else
            {
                isTopRight = false;
            }
        }

        else
        {
            if (item.itemType == "Top")
            {
                this.gameObject.GetComponent<Button>().interactable = true;//냉침기 버튼 클릭 가능해짐.
            }
            ClickedItem = item;
            Color color = CoolerOne.gameObject.GetComponent<Image>().color;
            color.a = 255;
            CoolerOne.gameObject.GetComponent<Image>().color = color;//아이템 제거

            Color color2 = CoolerTwo.gameObject.GetComponent<Image>().color;
            color2.a = 255;
            CoolerTwo.gameObject.GetComponent<Image>().color = color2;//아이템 제거

            Color color3 = CoolerThree.gameObject.GetComponent<Image>().color;
            color3.a = 255;
            CoolerThree.gameObject.GetComponent<Image>().color = color3;//아이템 제거
            if (ClickedItem.name == TopItemName)
            {
                Debug.Log("탑 향료 맞음");
                isTopRight = true;
            }
            else
            {
                isTopRight = false;
            }
        }
          
    }

    public void CoolerStart()//냉침기 자세히 보여지고 기능 시작. 
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == false)
        {
            if (isTopRight == true)
            {
                GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
                TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
                TotalScore.FindObjectOfType<TotalScore>().rightPrice += ClickedItem.itemPrice;
                TotalScore.FindObjectOfType<TotalScore>().RightItem += 1;
                TotalScore.FindObjectOfType<TotalScore>().UseItem += 1;
            }
            else if (isTopRight == false)
            {
                TotalScore.FindObjectOfType<TotalScore>().UseItem += 1;
                GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
                TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
            }
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("coolerTouch");
            GameObject.Find("Etc").transform.GetChild(7).gameObject.SetActive(false);
            GameObject.Find("Manufacture").transform.GetChild(7).gameObject.SetActive(false);
            Receipt.gameObject.SetActive(false);
            Invoke("CoolerDetailShow", 0.5f);
            GameObject.Find("InvenUI").GetComponent<Button>().interactable = false;

            if (ClickedItem.name == "기쁨")
            {
                CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[0];
                CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[0];
                CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[0];
            }
            if (ClickedItem.name == "사랑")
            {
                CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[1];
                CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[1];
                CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[1];
            }
            if (ClickedItem.name == "슬픔")
            {
                CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[2];
                CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[2];
                CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[2];
            }
            if (ClickedItem.name == "행복")
            {
                CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[3];
                CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[3];
                CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[3];
            }
            if (ClickedItem.name == "놀라움")
            {
                CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[4];
                CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[4];
                CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[4];
            }
            if (ClickedItem.name == "미움")
            {
                CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[5];
                CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[5];
                CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[5];
            }
            if (ClickedItem.name == "죄책감")
            {
                CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[6];
                CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[6];
                CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[6];
            }
            if (ClickedItem.name == "부끄러움")
            {
                CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[7];
                CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[7];
                CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[7];
            }
            if (ClickedItem.name == "의심")
            {
                CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[8];
                CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[8];
                CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[8];
            }
            // 선택한 탑 아이템 냉침 123에 세팅 완료
            Invoke("Cooling", 3.5f);
        }
        else//튜토리얼인 경우
        {
            GameObject.Find("MaskPanel").transform.GetChild(15).gameObject.SetActive(false);
            GameObject.Find("Mask_Arrow").transform.GetChild(10).gameObject.SetActive(false);
            GameObject.Find("TutorialDialogue").gameObject.SetActive(false);
            GameObject.Find("BlackPanel").SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(9).GetComponent<DailyResult>().originCost += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().originPrice += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().rightPrice += ClickedItem.itemPrice;
            TotalScore.FindObjectOfType<TotalScore>().RightItem += 1;
            TotalScore.FindObjectOfType<TotalScore>().UseItem += 1;

            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("coolerTouch");
            GameObject.Find("Etc").transform.GetChild(7).gameObject.SetActive(false);
            GameObject.Find("Manufacture").transform.GetChild(7).gameObject.SetActive(false);
            Receipt.gameObject.SetActive(false);
            Invoke("CoolerDetailShow", 0.5f);
            GameObject.Find("InvenUI").GetComponent<Button>().interactable = false;

            CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[0];
            CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[0];
            CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[0];

            Invoke("TutCool", 4.5f);
        }
    }
    public void TutCool()
    {
        GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().NextTutDialogue();
    }
    public void CoolerDetailShow()
    {
        CoolerDetail.gameObject.SetActive(true);
    }
    public void Cooling()
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == false)
        {
            if (ClickedItem.name.Equals("행복"))
            {
                Invoke("ParticleShow", 4f);
                Invoke("BurnItem", 6f);
            }
            else if (ClickedItem.name.Equals("기쁨"))
            {
                Invoke("ParticleShow", 2f);
                Invoke("BurnItem", 4f);
            }
            else if (ClickedItem.name.Equals("사랑"))
            {
                Invoke("ParticleShow", 4f);
                Invoke("BurnItem", 6f);
            }
            else if (ClickedItem.name.Equals("슬픔"))
            {
                Invoke("ParticleShow", 1f);
                Invoke("BurnItem", 3f);
            }
            else if (ClickedItem.name.Equals("미움"))
            {
                Invoke("ParticleShow", 8f);
                Invoke("BurnItem", 10f);
            }
            else if (ClickedItem.name.Equals("부끄러움"))
            {
                Invoke("ParticleShow", 6f);
                Invoke("BurnItem", 8f);
            }
            else if (ClickedItem.name.Equals("죄책감"))
            {
                Invoke("ParticleShow", 5f);
                Invoke("BurnItem", 7f);
            }
            else if (ClickedItem.name.Equals("의심"))
            {
                Invoke("ParticleShow", 4f);
                Invoke("BurnItem", 6f);
            }
            else if (ClickedItem.name.Equals("놀라움"))
            {
                Invoke("ParticleShow", 3f);
                Invoke("BurnItem", 5f);
            }
        }
        else
        {
            if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCooling == false)
            {
                Invoke("ParticleShow", 2f);
                Invoke("BurnItem", 4f);
            }
        }
    }
    public void CoolerClose()//냉침기 종료
    {
        GameObject.Find("Perfume").GetComponent<PerfumeColor>().FinishCnt++;
        GameObject.Find("Perfume").GetComponent<PerfumeColor>().PerfumeChoice(ClickedItem.name);
        isTopRight = false;
        TotalScore.FindObjectOfType<TotalScore>().CoolCnt++;
        for (int i = 0; i < GameObject.Find("TopInvenSlots").transform.childCount; i++)
        {
            GameObject.Find("TopInvenSlots").transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
        this.gameObject.GetComponent<Button>().interactable = false;
        Receipt.gameObject.SetActive(true);
        TotalScore.FindObjectOfType<TotalScore>().isCoolFin = true;
        CoolerDetail.gameObject.SetActive(false);
        GameObject.Find("InvenUI").GetComponent<Button>().interactable = true;

    }

    public void ParticleShow()//각 초 후에 파티클 생기고 클릭 가능해짐.
    {
        if(CoolerOne.gameObject.GetComponent<Image>().sprite != null)
        {
            Particle1.gameObject.SetActive(true);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("coolParticle");
            CoolerOne.GetComponent<Button>().interactable = true;
            CoolerOne.gameObject.tag = "good";
        }

        if (CoolerTwo.gameObject.GetComponent<Image>().sprite != null)
        {
            Particle2.gameObject.SetActive(true);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("coolParticle");
            CoolerTwo.GetComponent<Button>().interactable = true;
            CoolerTwo.gameObject.tag = "good";
        }

        if (CoolerThree.gameObject.GetComponent<Image>().sprite != null)
        {
            Particle3.gameObject.SetActive(true);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("coolParticle");
            CoolerThree.GetComponent<Button>().interactable = true;
            CoolerThree.gameObject.tag = "good";
        }
    }

    public void BurnItem()//파티클 생성 후 2초 뒤에 아이템 탄 이미지로 변환,
    {
        //여기에 아이템 이름별로 다르게 탄 이미지 변경하도록 조건문 추가해야함.

        Particle1.gameObject.SetActive(false);
        Particle2.gameObject.SetActive(false);
        Particle3.gameObject.SetActive(false);

        CoolerOne.gameObject.GetComponent<Image>().sprite = ItemBurnSprites[0];
        CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemBurnSprites[0];
        CoolerThree.gameObject.GetComponent<Image>().sprite = ItemBurnSprites[0];

        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("coolFail");
        CoolerOne.gameObject.tag = "bad";
        CoolerTwo.gameObject.tag = "bad";
        CoolerThree.gameObject.tag = "bad";
        //GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("coolPick");
    }

    public void ItemResult(GameObject itemResult)//아이템 수거
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == false)
        {
            if (itemResult.gameObject.tag == "good")
            {
                if (itemResult.name == "Cool1")
                {
                    Particle1.gameObject.SetActive(false);
                }
                else if (itemResult.name == "Cool2")
                {
                    Particle2.gameObject.SetActive(false);
                }

                else if (itemResult.name == "Cool3")
                {
                    Particle3.gameObject.SetActive(false);
                }
                goodCount += 1;
            }

            itemResult.gameObject.GetComponent<Image>().sprite = null;
            Color color = itemResult.gameObject.GetComponent<Image>().color;
            color.a = 0;
            itemResult.gameObject.GetComponent<Image>().color = color;//아이템 제거
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("coolPick");

            if (itemResult.gameObject.tag == "bad")
            {
                goodCount += 0;
            }//굿이면 1 추가, 배드면 0 추가

            ResultCount += 1;

            if (ResultCount == 3)
            {
                CoolTotalScore();
                this.GetComponent<Button>().interactable = false;
                Invoke("CoolerClose", 2);
                ResultCount = 0;
            }
        }
        else
        {
            if (itemResult.gameObject.tag == "good")
            {
                if (itemResult.name == "Cool1")
                {
                    Particle1.gameObject.SetActive(false);
                }
                else if (itemResult.name == "Cool2")
                {
                    Particle2.gameObject.SetActive(false);
                }

                else if (itemResult.name == "Cool3")
                {
                    Particle3.gameObject.SetActive(false);
                }
                goodCount += 1;
            }

            itemResult.gameObject.GetComponent<Image>().sprite = null;
            Color color = itemResult.gameObject.GetComponent<Image>().color;
            color.a = 0;
            itemResult.gameObject.GetComponent<Image>().color = color;//아이템 제거
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySFX("coolPick");

            if (itemResult.gameObject.tag == "bad")
            {
                goodCount += 0;
            }//굿이면 1 추가, 배드면 0 추가

            ResultCount += 1;

            if (ResultCount == 3)
            {
                CoolTotalScore();
                this.GetComponent<Button>().interactable = false;
                ResultCount = 0;
            }
         }
    }

    public void CoolTotalScore()
    {
        if (GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCreate == false)
        {
            if (goodCount == 3)
            {
                TotalScore.FindObjectOfType<TotalScore>().isCoolGood = true;
            }

            else if (goodCount == 2)
            {
                TotalScore.FindObjectOfType<TotalScore>().isCoolNormal = true;
            }
            else
            {
                TotalScore.FindObjectOfType<TotalScore>().isCoolBad = true;
            }
        }
        else
        {
            if (goodCount == 3)
            {
                TotalScore.FindObjectOfType<TotalScore>().isCoolGood = true;
                Invoke("CoolerClose", 2);
                GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().createCnt = 42;
                GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().NextTutDialogue();
            }
            else
            {
                GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().TutCoolBad();
                GameObject.Find("Panels").transform.GetChild(9).GetComponent<Tutorial>().isTutCooling = true;
                CoolerOne.gameObject.GetComponent<Image>().sprite = ItemSprites[0];
                CoolerTwo.gameObject.GetComponent<Image>().sprite = ItemSprites[0];
                CoolerThree.gameObject.GetComponent<Image>().sprite = ItemSprites[0];

                Color color = CoolerOne.gameObject.GetComponent<Image>().color;
                color.a = 255;
                CoolerOne.gameObject.GetComponent<Image>().color = color;//아이템 제거

                Color color2 = CoolerTwo.gameObject.GetComponent<Image>().color;
                color2.a = 255;
                CoolerTwo.gameObject.GetComponent<Image>().color = color2;//아이템 제거

                Color color3 = CoolerThree.gameObject.GetComponent<Image>().color;
                color3.a = 255;
                CoolerThree.gameObject.GetComponent<Image>().color = color3;//아이템 제거
                goodCount = 0;
                ResultCount = 0;
                Particle1.gameObject.SetActive(false);
                Particle2.gameObject.SetActive(false);
                Particle3.gameObject.SetActive(false);
            }
        }
    }
}
