using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Animation")]
    public float finalScale = 1.2f;
    public float animationDuration = .1f;

    private Vector3 _defaultScale;

    private Tween _currentTween;

    private void Awake()
    {
        _defaultScale = transform.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        transform.DOScale(_defaultScale * finalScale, animationDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        _currentTween.Kill();
        transform.localScale = _defaultScale;
    }
}
