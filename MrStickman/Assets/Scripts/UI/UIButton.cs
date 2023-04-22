using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ButtonType
{
    None,
    Move,
    Scale,
    Tilt
}

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private ButtonType buttonType;
    [SerializeField] private float newValue = 1f;
    [SerializeField] private float duration = 0.25f;

    private float _defaultPositionOrRotation;
    private Vector3 _defaultScale;
    
    private void Awake()
    {
        switch (buttonType)
        {
            case ButtonType.None:
                break;
            case ButtonType.Move:
                _defaultPositionOrRotation = transform.GetComponent<RectTransform>().anchoredPosition.y;
                break;
            case ButtonType.Scale:
                _defaultScale = transform.localScale;
                break;
            case ButtonType.Tilt:
                _defaultPositionOrRotation = transform.localRotation.eulerAngles.z;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (buttonType)
        {
            case ButtonType.None:
                break;
            case ButtonType.Move:
                var rect = transform.GetComponent<RectTransform>();
                rect.DOAnchorPosY(newValue, duration);
                break;
            case ButtonType.Scale:
                transform.DOScale(newValue, duration);
                break;
            case ButtonType.Tilt:
                var euler = transform.localRotation.eulerAngles;
                transform.DOLocalRotate(new Vector3(euler.x, euler.y, newValue), duration);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        switch (buttonType)
        {
            case ButtonType.None:
                break;
            case ButtonType.Move:
                var rect = transform.GetComponent<RectTransform>();
                rect.DOAnchorPosY(_defaultPositionOrRotation, duration);
                break;
            case ButtonType.Scale:
                transform.DOScale(_defaultScale, duration);
                break;
            case ButtonType.Tilt:
                var euler = transform.localRotation.eulerAngles;
                transform.DOLocalRotate(new Vector3(euler.x, euler.y, _defaultPositionOrRotation), duration);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (buttonType)
        {
            case ButtonType.None:
                break;
            case ButtonType.Move:
                var rect = transform.GetComponent<RectTransform>();
                rect.DOAnchorPosY(_defaultPositionOrRotation, duration);
                break;
            case ButtonType.Scale:
                transform.DOScale(_defaultScale, duration);
                break;
            case ButtonType.Tilt:
                var euler = transform.localRotation.eulerAngles;
                transform.DOLocalRotate(new Vector3(euler.x, euler.y, _defaultPositionOrRotation), duration);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
