using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class CutScene : MonoBehaviour
{
    [Header("Data")] 
    [SerializeField] private PlaceController placeController;
    
    [Header("Variable")]
    [SerializeField] private float fadeTime;
    [SerializeField] private float faceFadeTime;
    
    [Header("Image")]
    [SerializeField] private Image backGround;
    [SerializeField] private Image personLeft;
    [SerializeField] private Image personRight;
    private const string backGroundPath = "MoveSystem/BackGround/";
    private const string facePath = "MoveSystem/Face/";
    private bool leftActive;
    private bool rightActive;
    
    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI dialogFild;
    [SerializeField] private TextMeshProUGUI dialogName;
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject tailLeft;
    [SerializeField] private GameObject tailRight;
    [SerializeField] private GameObject nameBox;

    [Header("Fade")] 
    [SerializeField] private UnityEvent fadeInOut;

    [Header("Effect")] 
    [SerializeField] private GameObject mapEffects;
    //[SerializeField] private GameObject dialogueEffects;

    private List<PlaceDialogDBEntity> data;
    private List<string> person;
    
    private bool isSpace = false;

    private IEnumerator SetBackGround()
    {
        yield return new WaitForSeconds(fadeTime);

        backGround.gameObject.SetActive(true);
        textBox.gameObject.SetActive(true);
        mapEffects.SetActive(false);

        leftActive = false;
        rightActive = false;

        foreach (var item in data)
        {
            backGround.sprite = Resources.Load(backGroundPath + item.placeImage, typeof(Sprite)) as Sprite;
            float t = 0;

            if (person.Count != 0 && item.name != String.Empty)
            {
                int i;
                for (i = 0; i < person.Count; i++)
                {
                    if (person[i].Equals(item.name))
                    {
                        break;
                    }
                }
                
                nameBox.SetActive(true);

                if (i % 2 == 0)
                {
                    tailRight.SetActive(false);
                    tailLeft.SetActive(true);
                    personLeft.color = new Color(1, 1, 1, 1);

                    leftActive = true;
                    if (rightActive)
                    {
                        StartCoroutine(FaceLerp(personRight, faceFadeTime));

                        rightActive = false;
                    }

                    personLeft.sprite = Resources.Load(facePath + item.face, typeof(Sprite)) as Sprite;
                }
                else
                {
                    tailLeft.SetActive(false);
                    tailRight.SetActive(true);
                    personRight.color = new Color(1, 1, 1, 1);

                    rightActive = true;
                    if (leftActive)
                    {
                        StartCoroutine(FaceLerp(personLeft, faceFadeTime));

                        leftActive = false;
                    }

                    personRight.sprite = Resources.Load(facePath + item.face, typeof(Sprite)) as Sprite;
                }
            }
            else
            {
                tailLeft.SetActive(false);
                tailRight.SetActive(false);
                personRight.color = new Color(0, 0, 0, 0);
                personLeft.color = new Color(0, 0, 0, 0);
                
                nameBox.SetActive(false);
            }

            // Set the name and dialog text
            dialogName.text = item.name;
            string text = item.dialog.Replace("\\n", "\n");

            for (int i = 0; i <= text.Length; i++)
            {
                if (isSpace) // 스페이스바를 눌렀으면
                {
                    i = text.Length; // 현재 대사를 모두 출력하고
                    isSpace = false; // 스페이스바 눌림 상태를 초기화한다
                }

                dialogFild.text = text.Substring(0, i);
                yield return new WaitForSeconds(0.07f);
            }

            // 스페이스바를 한 번 더 누르기 전까지 대기
            while (!isSpace)
            {
                yield return null;
            }

            isSpace = false; // 스페이스바 눌림 상태 초기화
        }
        
        fadeInOut?.Invoke();
        yield return new WaitForSeconds(fadeTime);

        mapEffects.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpace = true;
        }
    }

    public void SpaceClick()
    {
        isSpace = true;
    }
    
    private IEnumerator FaceLerp(Image image, float time)
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / time; // fadeTime에 따라 알파값 변화 속도 조절
            image.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(0.5f, 0.5f, 0.5f, 1f), t);
            yield return null;
        }
    }


    public void SetUp(ToolTip toolTip)
    {
        fadeInOut?.Invoke();
        
        data = placeController.GetPlaceDialogData(GameDataManager.Instance.Day, toolTip.button);
        person = new List<string>();

        foreach (var item in data)
        {
            if (!person.Contains(item.name) && item.name != String.Empty)
            {
                person.Add(item.name);
            }
        }
        
        personRight.color = new Color(0, 0, 0, 0);
        personLeft.color = new Color(0, 0, 0, 0);
        backGround.gameObject.SetActive(false);
        textBox.gameObject.SetActive(false);
        tailLeft.SetActive(false);
        tailRight.SetActive(false);

        StartCoroutine(SetBackGround());
    }
}
