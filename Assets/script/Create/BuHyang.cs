using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuHyang : MonoBehaviour
{
    public GameObject SliderCursor;
    public GameObject BarCursor;

    // 제조 결과
    public GameObject Desk;
    public GameObject TotalScore;

    int sliderCursorDir;
    float sliderCursorSpeed;
    bool isSliderMovable;

    int buHyangCnt = 0;
    int buHyangMaxCnt = 5;

    
    float buHyangValue = 0.0f;
    float successIncreaseValue = 6.0f;
    float greatSuccessIncreaseValue = 10.0f;
    float failDecreaseValue = -6.0f;
    float greatFailDecreaseValue = -10.0f;
    
    // 성공 영역
    float bound = 140.0f;
    float successOffset = 90.0f;
    float successLength = 100.0f;
    float greatSuccessLength = 10.0f;

    void OnEnable()
    {
        sliderCursorDir = 1;
        sliderCursorSpeed = 500.0f;
        isSliderMovable = true;

        buHyangCnt = 0;
        buHyangValue = 0.0f;

        BarCursor.transform.localPosition = new Vector3(13.9f, -100.0f);
    }

    void Update()
    {
        float xDeltaPos = sliderCursorDir * sliderCursorSpeed * Time.deltaTime;
        
        if (isSliderMovable)
        {
            SliderCursor.transform.position += new Vector3(xDeltaPos, 0);
        }
        
        float sliderCursorXpos = SliderCursor.transform.localPosition.x;

        // 범위 벗어나면 방향 전환
        if (sliderCursorXpos > bound || sliderCursorXpos < -bound)
        {
            sliderCursorDir *= -1;
        }

        if(Input.GetMouseButtonDown(0) && buHyangCnt < buHyangMaxCnt)
        {
            float leftSuccessBound = -bound + successOffset;
            float rightSuccessBound = leftSuccessBound + successLength;
            float leftGreatSuccessBound = leftSuccessBound + (successLength / 2.0f) - (greatSuccessLength / 2.0f);
            float rightGreatSuccessBound = leftGreatSuccessBound + greatSuccessLength;

            // 검사
            if (sliderCursorXpos >= leftSuccessBound && sliderCursorXpos <= rightSuccessBound)
            {
                // 대성공
                if(sliderCursorXpos >= leftGreatSuccessBound && sliderCursorXpos <= rightGreatSuccessBound)
                {
                    AddBuHyangValue(greatSuccessIncreaseValue);
                    Debug.Log("대성공!");
                }
                // 성공
                else
                {
                    AddBuHyangValue(successIncreaseValue);
                    Debug.Log("성공");
                }
            }
            // 실패
            else
            {
                AddBuHyangValue(failDecreaseValue);
                Debug.Log("실패");
            }
            
            // 대실패?
            buHyangCnt += 1;
            
            if (buHyangMaxCnt == buHyangCnt)
            {
                isSliderMovable = false;
                StartCoroutine(CloseWindow());
            }
            else
            {
                SliderCursor.transform.localPosition = new Vector3(-bound, 0);
                sliderCursorDir = 1;
                sliderCursorSpeed *= 1.3f;
            }
        }
    }

    void AddBuHyangValue(float value)
    {
        buHyangValue += value;

        if(buHyangValue < 0)
        {
            buHyangValue = 0;
        }

        Debug.Log(value);
        MoveBarCursor(value);
    }

    void MoveBarCursor(float offset)
    {
        BarCursor.transform.localPosition += new Vector3(0, offset * 5);

        if (BarCursor.transform.localPosition.y < -100)
        {
            BarCursor.transform.localPosition = new Vector3(BarCursor.transform.localPosition.x, -100);
        }
    }

    IEnumerator CloseWindow()
    {
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
        Desk.GetComponent<DeskTouch>().TouchPerfume();
        TotalScore.GetComponent<TotalScore>().Calculate();
    }
}
