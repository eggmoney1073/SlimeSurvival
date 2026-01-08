using UnityEngine;

public class InventoryInteractionFieldController : MonoBehaviour
{
    [SerializeField]
    SelectedSlotController _selectedSlot;

    RectTransform _rectTransfrom;
    Camera _mainCam;
    Vector2 _screenPositon;

    void SetScreenPosition(Vector2 screenPosition)
    {
        _screenPositon = screenPosition;
        Vector2 outLocalPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransfrom, _screenPositon, null, out outLocalPosition))
        {
            float halfWidth = _rectTransfrom.rect.width * 0.5f;
            float halfHeight = _rectTransfrom.rect.height * 0.5f;

            float adjustedX = outLocalPosition.x + halfWidth;
            float adjustedY = halfHeight - outLocalPosition.y;

            int col = Mathf.FloorToInt(adjustedX / UIConstants.Base_Slot_Size);
            int row = Mathf.FloorToInt(adjustedY / UIConstants.Base_Slot_Size);

            if (col < 0 || col >= 6 || row < 0 || row >= 9)
            {
                _selectedSlot.SetSelectedSlotPosition(0, 0);
            }
            _selectedSlot.SetSelectedSlotPosition(col, row);
        }
    }

    void Start()
    {
        _rectTransfrom = GetComponent<RectTransform>();
        _mainCam = Camera.main;

        //InputManager._Instance._onMousePositionChanged_Vector2 += SetScreenPosition;
    }

    void Update()
    {

    }

    void OnDestroy()
    {
        //InputManager._Instance._onMousePositionChanged_Vector2 -= SetScreenPosition;
    }
}
