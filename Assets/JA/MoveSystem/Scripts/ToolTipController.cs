using TMPro;
using UnityEngine;

public class ToolTipController : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI proUGUI;
    private const string visitAsk = "을(를) 방문하시겠습니까?";
    private const string notVisiteAsk = "아직 방문하지 않은 중요한 장소가 남아 있습니다. 그래도 돌아가시겠습니까?";
    private const string goBackAsk = "향수 공방으로 돌아가시겠습니까?";

    [Header("ETC")]
    [SerializeField] private GameObject explanation;
    
    [Header("CutScene")]
    [SerializeField] private CutScene cutScene;

    [Header("Places")] 
    [SerializeField] private PlaceController placeController;
    
    private ToolTip _toolTip;
    
    public void SetUp(ToolTip tip)
    {
        _toolTip = tip;
        proUGUI.text = default;
        string titleText = default;

        if (tip.button == Enums.MoveButton.RootOfReadButton)
        {
            if (placeController.SpecialNum > 0)
            {
                titleText = notVisiteAsk;
            }
            else if (placeController.VisitableNum > 1)
            {
                titleText = $"아직 방문하지 않은 장소가 {placeController.VisitableNum - 1}개 있습니다. 그래도 돌아가시겠습니까?";
            }
            else
            {
                titleText = goBackAsk;
            }
        }
        else
        {
            titleText = tip.name + visitAsk;
        }

        proUGUI.text = titleText;

        _toolTip = tip;
    }

    public void CutSceneLoad()
    {
        // 컷씬 나오고 ~~
        this.gameObject.SetActive(false);

        if (_toolTip != null)
        {
            cutScene.gameObject.SetActive(true);
            cutScene.SetUp(_toolTip);
            placeController.VisitPlace(_toolTip.button);
        }
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
