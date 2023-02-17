using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CutScene : MonoBehaviour
{
    [Header("Data")] 
    [SerializeField] private PlaceController placeController;
    
    [Header("Variable")]
    [SerializeField] private float fadeTime;
    
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

    [Header("Fade")] 
    [SerializeField] private DOTweenAnimation fade;

    [Header("Effect")] 
    [SerializeField] private GameObject mapEffects;
    //[SerializeField] private GameObject dialogueEffects;

    private List<PlaceDialogDBEntity> data;
    private List<string> person; 
    
    private void Awake()
    {
        //StartCoroutine(SetBackGround());
    }
    
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

            if (person.Count != 0)
            {
                int i;
                for (i = 0; i < person.Count; i++)
                {
                    if (person[i].Equals(item.name))
                    {
                        break;
                    }
                }
                if (i % 2 == 0)
                {
                    tailRight.SetActive(false);
                    tailLeft.SetActive(true);
                    personLeft.color = new Color(1,1,1,1);

                    leftActive = true;
                    if (rightActive)
                    {
                        personRight.color = new Color(0.5f,0.5f,0.5f,1f);
                    }

                    personLeft.sprite = Resources.Load(facePath + item.face, typeof(Sprite)) as Sprite;
                }
                else
                {
                    tailLeft.SetActive(false);
                    tailRight.SetActive(true);
                    personRight.color = new Color(1,1,1,1);

                    rightActive = true;
                    if (leftActive)
                    {
                        personLeft.color = new Color(0.5f,0.5f,0.5f,1f);
                    }

                    personRight.sprite = Resources.Load(facePath + item.face, typeof(Sprite)) as Sprite;
                }
            }
            
            dialogFild.text = item.dialog;
            dialogName.text = item.name;
            
            yield return new WaitForSeconds(fadeTime);
        }

        fade.DORestart();
        
        yield return new WaitForSeconds(fadeTime);

        mapEffects.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void SetUp(ToolTip toolTip)
    {
        fade.DORestart();
        
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
