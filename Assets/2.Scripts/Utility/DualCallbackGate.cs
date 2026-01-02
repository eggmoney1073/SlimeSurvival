using System;

/// <summary>
/// 두 개의 콜백이 모두 호출되었을 때 완료 콜백을 실행하는 게이트
/// </summary>
public sealed class DualCallbackGate
{
    bool _isCallbackACalled = false;
    bool _isCallbackBCalled = false;
    bool _isAllreadyInvoked = false;

    Action _onCompleted;

    public DualCallbackGate(Action onCompleted)
    {
        _onCompleted = onCompleted;
    }

    public void CallbackA()
    {
        _isCallbackACalled = true;
        TryInvoke();
    }

    public void CallbackB()
    {
        _isCallbackBCalled = true;
        TryInvoke();
    }

    void TryInvoke()
    {
        // 이미 콜백 작동했으면 리턴
        if (_isAllreadyInvoked)
        {
            return;
        }

        if (_isCallbackACalled && _isCallbackBCalled)
        {
            _onCompleted?.Invoke();
            _isAllreadyInvoked = true;
        }
    }
}
