using UnityEngine;
using UnityEngine.SceneManagement;
public class Place : MonoBehaviour
{
    [Header("SetValue")] 
    [SerializeField] private Enums.MoveButton moveButton;
    [SerializeField] private string placeName;

    private ToolTip _toolTip;
    private bool _isVisitable;
    private bool _isSpecial;
    
    public bool IsVisitable { get { return _isVisitable;} }
    public bool IsSpecial { get { return _isSpecial;} }
    public Enums.MoveButton PlaceState { get { return moveButton; } }

    [Header("PlaceVisibilityController")]
    [SerializeField] private PlaceVisibilityController placeVisibilityController;
    
    [Header("ToolTipController")]
    [SerializeField] private ToolTipController toolTipController;

    private void Awake()
    {
        _toolTip = new ToolTip(moveButton, placeName);
        _isVisitable = false;
        _isSpecial = false; // 이후 초기화 안되면 해결

        //Rendering();
    }

    public void TryVisitPlace(Enums.MoveButton placeType)
    {
        if (placeType == _toolTip.button)
        {
            _isVisitable = false;
            _isSpecial = false;
            Rendering();
        }
    }
    
    public void Move() 
    {
        if (_toolTip.button == Enums.MoveButton.RootOfReadButton)
        {
            SceneManager.LoadScene("main");
        }

        toolTipController.SetUp(_toolTip);
        toolTipController.gameObject.SetActive(true);
    }
    
    public void SetVisitable(bool isSpecial)
    {
        if (isSpecial)
            _isSpecial = true;
        _isVisitable = true;
    }

    public void Rendering()
    {
        placeVisibilityController.SetUp(_isVisitable, _isSpecial);
    }
}
