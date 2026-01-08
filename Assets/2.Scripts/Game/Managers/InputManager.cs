//using System;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using DefineEnums;
//using System.Collections.Generic;

//public class InputManager : SingletonDontDestroyOnLoad<InputManager>
//{
//    PlayerInput _input;
//    InputActionAsset _inputActionAsset;

//    #region [ Action Parameters ]
//    /// <summary>
//    /// Move Input 입력시
//    /// </summary>
//    public Action<Vector2> _onMoveInput_Vector2;

//    /// <summary>
//    /// 마우스 움직일시 (마우스 스크린 좌표)
//    /// </summary>
//    //public Action<Vector2> _onMousePositionChanged_Vector2;

//    /// <summary>
//    /// 마우스 움직일시 (마우스 스크린 좌표)
//    /// </summary>
//    public Action<Vector2> _onMousePositionChanged_Vector2;

//    /// <summary>
//    /// 마우스 좌클릭
//    /// </summary>
//    public Action _mouseLeftClickStarted;
//    public Action _mouseLeftClickPerformed;
//    public Action _mouseLeftClickCanceled;

//    /// <summary>
//    /// 마우스 좌클릭 (마우스 스크린 좌표)
//    /// </summary>
//    public Action<Vector2> _mouseLeftClickStarted_Vector2;
//    public Action<Vector2> _mouseLeftClickPerformed_Vector2;
//    public Action<Vector2> _mouseLeftClickCanceled_Vector2;

//    #endregion

//    Vector2 _mousePosition;
//    public Vector2 _MousePosition { get { return _mousePosition; } }

//    Dictionary<Input_Action_Maps, InputActionMap> _inputActionMapDictionary;

//    #region [ Input Events ]
//    /// <summary>
//    /// 마우스 움직임 이벤트
//    /// </summary>
//    public void Event_Aim(InputAction.CallbackContext context)
//    {
//        _mousePosition = context.ReadValue<Vector2>();

//        if (_onMousePositionChanged_Vector2 != null)
//            _onMousePositionChanged_Vector2.Invoke(_mousePosition);
//    }

//    /// <summary>
//    /// 마우스 좌클릭 이벤트
//    /// </summary>
//    public void Event_LeftMouseClick(InputAction.CallbackContext context)
//    {
//        if (context.performed)
//        {

//        }
//#if UNITY_ANDROID || UNITY_EDITOR

//        if (_mouseLeftClickStarted_Vector2 != null)
//            _mouseLeftClickStarted_Vector2.Invoke(_mousePosition);

//        if (_mouseLeftClickStarted != null)
//            _mouseLeftClickStarted.Invoke();

//#elif UNITY_STANDALONE
//        if (context.started)
//        {
//            _mouseOnClickStarted.Invoke(_mousePosition);
//        }
//        else if (context.canceled)
//        {
//            _mouseOnClickCanceled.Invoke(_mousePosition);
//        }
//#endif
//    }

//    /// <summary>
//    /// 마우스 우클릭 이벤트
//    /// </summary>
//    public void Event_RightMouseClick(InputAction.CallbackContext context)
//    {

//    }

//    /// <summary>
//    /// 캐릭터 이동 이벤트
//    /// </summary>
//    public void Event_Move(InputAction.CallbackContext context)
//    {
//        Debug.Log(context.ReadValue<Vector2>());
//        if (_onMoveInput_Vector2 != null)
//            _onMoveInput_Vector2.Invoke(context.ReadValue<Vector2>());
//    }

//    /// <summary>
//    /// 크로스헤어 이동 이벤트
//    /// </summary>
//    public void Event_CrossHairMove(InputAction.CallbackContext context)
//    {
//        Debug.Log("실패");
//        Debug.Log("타이틀, 인게임 플레이어, 인게임 ui를 나눠서 action을 그 때 그때 설정");
//        //Debug.Log("Event_CrossHairMove input");
//        //Debug.Log(context.ReadValue<Vector2>());

//        //if (_onMoveInput_Vector2 != null)
//        //    _onMoveInput_Vector2.Invoke(context.ReadValue<Vector2>());
//    }

//    public void Event_TitleExit(InputAction.CallbackContext context)
//    {
//        Debug.Log("Exit");
//    }

//    public void Event_TitleClick(InputAction.CallbackContext context)
//    {
//        _mouseLeftClickStarted_Vector2.Invoke(_mousePosition);
//    }

//    public void Event_TitlePosition(InputAction.CallbackContext context)
//    {
//        _mousePosition = context.ReadValue<Vector2>();
//    }

//    #endregion

//    #region [ Public Methods ]

//    public void SettingActionMap(Input_Action_Maps actionMap)
//    {
//        DisableAllActionMap();
//        EnableActionMap(actionMap);
//    }

//    #endregion

//    #region [ Private Methods ]

//    void InitializeActionMap()
//    {
//        _inputActionMapDictionary = new Dictionary<Input_Action_Maps, InputActionMap>();

//        int actionMapCount = (int)Input_Action_Maps.Max;

//        for(int i = 1; i < actionMapCount; i++)
//        {
//            Input_Action_Maps actionMapEnum = (Input_Action_Maps)i;
//            InputActionMap actionMap = _inputActionAsset.FindActionMap((actionMapEnum).ToString());
//            _inputActionMapDictionary.Add(actionMapEnum, actionMap);
//        }
//    }

//    void EnableActionMap(Input_Action_Maps actionMap)
//    {
//        _inputActionMapDictionary[actionMap].Enable();
//    }

//    void DisableAllActionMap()
//    {
//        foreach(KeyValuePair<Input_Action_Maps, InputActionMap> keyValuePair in _inputActionMapDictionary)
//        {
//            keyValuePair.Value.Disable();
//        }
//    }

//    #endregion

//    #region [ Unity Functions ]
//    void Start()
//    {
//        _input = GetComponent<PlayerInput>();
//        _inputActionAsset = _input.actions;

//        Initialize();
//    }

//    public void Initialize()
//    {
//        InitializeActionMap();
//    }

//    #endregion
//}
