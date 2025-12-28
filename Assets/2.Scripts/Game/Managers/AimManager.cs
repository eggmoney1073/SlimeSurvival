using System;
using UnityEngine;

public class AimManager : SingletonGameobject<AimManager>
{
    [SerializeField]
    LayerMask _groundLayer;

    public Action<Vector3> _onPointedGroundChanged_Vector3;

    Camera _mainCam;

    Vector3 _aimPosition;
    public Vector3 _AimPosition { get { return _aimPosition; } }

    void SetAimPosition(Vector2 mousePosition)
    {
        Ray ray = _mainCam.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, _groundLayer))
        {
            _aimPosition = hit.point;
        }

        _onPointedGroundChanged_Vector3.Invoke(_aimPosition);
    }

    void Start()
    {
        _mainCam = Camera.main;
        InputManager._Instance._onMousePositionChanged_Vector2 += SetAimPosition;
    }

    void OnDestroy()
    {
        InputManager._Instance._onMousePositionChanged_Vector2 -= SetAimPosition;

    }
}
