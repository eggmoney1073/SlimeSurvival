using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TouchEffectController : MonoBehaviour
{
    [SerializeField]
    float _effectDuration = 1f;

    const float _MaxSize = 100f;

    float _sizeDelta = _MaxSize;
    float _alphaDelta;

    Image[] _circles;
    Image[] _stars;
    Coroutine _effectCorutine;
    Coroutine[] _imageCorutines;
    RectTransform _rect;
    TouchEffectManager _effectManager;

    public void Initialize(TouchEffectManager touchManager)
    {
        _effectManager = touchManager;

        _sizeDelta = _MaxSize / _effectDuration;
        _alphaDelta = 0.6f / _effectDuration;

        _imageCorutines = new Coroutine[3];

        _rect = GetComponent<RectTransform>();

        int childCount = transform.childCount;
        _circles = new Image[3];
        _stars = new Image[3];

        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);

            for (int j = 0; j < child.childCount; j++)
            {
                if (i == 0)
                    _circles[j] = child.GetChild(j).GetComponent<Image>();
                else if(i == 1)
                    _stars[j] = child.GetChild(j).GetComponent<Image>();
            }
        }
    }

    public void EffectStart(Vector2 position)
    {
        _rect.anchoredPosition = position;
        Effect();
    }

    void Effect()
    {
        if (_effectCorutine != null)
        {
            InitializeEffect();
            StopCoroutine(_effectCorutine);
        }

        _effectCorutine = StartCoroutine(Co_3Effects());
    }

    IEnumerator Co_3Effects()
    {
        for (int i = 0; i < _circles.Length; i++)
        {
            _circles[i].gameObject.SetActive(true);
        }

        if (_imageCorutines[0] != null)
            StopCoroutine(_imageCorutines[0]);

        _imageCorutines[0] = StartCoroutine(Co_Effect(_circles[0]));

        yield return new WaitForSeconds(0.1f);

        if (_imageCorutines[1] != null)
            StopCoroutine(_imageCorutines[1]);

        _imageCorutines[1] = StartCoroutine(Co_Effect(_circles[1]));

        yield return new WaitForSeconds(0.1f);

        if (_imageCorutines[2] != null)
            StopCoroutine(_imageCorutines[2]);

        _imageCorutines[2] = StartCoroutine(Co_Effect(_circles[2]));

        yield return new WaitForSeconds(_effectDuration);

        InitializeEffect();
        _effectManager._touchEffectPool.Set(this);
    }

    IEnumerator Co_Effect(Image circle)
    {
        float checkTime = 0;

        while (checkTime <= _effectDuration)
        {
            float size = _sizeDelta * checkTime;
            circle.rectTransform.sizeDelta = new Vector2(size, size);
            circle.color = new Color(1, 1, 1, 1 - (_alphaDelta * checkTime));
            yield return null;
            checkTime += Time.deltaTime;
        }
    }

    void InitializeEffect()
    {
        for (int i = 0; i < _circles.Length; i++)
        {
            _circles[i].color = new Color(1, 1, 1, 0);
            _circles[i].gameObject.SetActive(false);
        }
    }
}
