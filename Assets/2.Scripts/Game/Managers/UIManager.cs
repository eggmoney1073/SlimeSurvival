using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{

    int _canvasCount;
    CanvasScaler[] _uiScalers;

    public void Initialize()
    {
        _canvasCount = transform.childCount;

        _uiScalers = new CanvasScaler[_canvasCount];

        for (int i = 0; i < _canvasCount; i++)
        {
            CanvasScaler scaler = transform.GetChild(i).GetComponent<CanvasScaler>();
            SetScale(scaler);
            _uiScalers[i] = scaler;
        }
    }

    void SetScale(CanvasScaler scaler)
    {
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(Screen.width, Screen.height);
        scaler.matchWidthOrHeight = 0.5f;
    }

    void Start()
    {
        Initialize();
    }

#if UNITY_EDITOR
    void Update()
    {
        for (int i = 0; i < _canvasCount; i++)
        {
            SetScale(_uiScalers[i]);
        }
    }
#endif
}
