using UnityEngine;

public class TouchEffectManager : MonoBehaviour
{
    [SerializeField]
    GameObject _effectPrefab;

    public GameObjectPool<TouchEffectController> _touchEffectPool;

    void EffectAppear(Vector2 position)
    {
        TouchEffectController effect = _touchEffectPool.Get();
        effect.EffectStart(position);
    }

    void Start()
    {
        _touchEffectPool = new GameObjectPool<TouchEffectController>(2, () =>
        {
            GameObject effect = Instantiate(_effectPrefab);
            effect.transform.SetParent(transform);
            TouchEffectController effectController = effect.GetComponent<TouchEffectController>();
            effectController.Initialize(this);
            return effectController;
        });

        //InputManager._Instance._mouseLeftClickStarted_Vector2 += EffectAppear;
    }

    void OnDestroy()
    {
        //InputManager._Instance._mouseLeftClickStarted_Vector2 -= EffectAppear;
    }
}
