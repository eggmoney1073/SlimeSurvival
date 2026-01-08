using UnityEngine;

public class TitleSlimeController : MonoBehaviour
{
    [SerializeField]
    float _rotateSpeed = 5f;
    [SerializeField]
    LayerMask _groundLayer;

    Camera _mainCam;
    Vector3 _slimeLookPosition = Vector3.zero;

    public void Initialize()
    {
#if UNITY_ANDROID
        Debug.Log("UNITY_ANDROID");

        _mainCam = Camera.main;
        InputManager._Instance._mouseLeftClickStarted_Vector2 += SetSlimeLookPosition;

#elif UNITY_STANDALONE || UNITY_EDITOR
        Debug.Log("UNITY_STANDALONE");
#endif

    }

    void SetSlimeLookPosition(Vector2 aimPosition)
    {
        Ray ray = _mainCam.ScreenPointToRay(aimPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f, _groundLayer))
        {
            _slimeLookPosition = hit.point;
        }
    }

    void RotateSlime()
    {
        if (_slimeLookPosition != Vector3.zero)
        {
            Quaternion quaternionDirection = Quaternion.LookRotation(_slimeLookPosition);
            transform.rotation = Quaternion.Slerp(transform.rotation, quaternionDirection, _rotateSpeed * Time.deltaTime);
        }
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        RotateSlime();
    }

    void OnDestroy()
    {
        //InputManager._Instance._mouseLeftClickStarted_Vector2 -= SetSlimeLookPosition;
    }
}
