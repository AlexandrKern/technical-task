using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Компонент для управления анимацией кнопки при взаимодействии с пользователем.
/// </summary>
public class ButtonController : MonoBehaviour, IPointerExitHandler,IPointerEnterHandler,IPointerUpHandler,IPointerDownHandler
{
    [SerializeField] private ButtonType _buttonType;
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private float _minSize = 0.1f;
    [SerializeField] private float _maxSize = 0.1f;
    [SerializeField] private Color _color;
    [SerializeField] private UIController _uiСontroller;

    private float _originSize;
    private Transform _transform;
    private Image _image;
    private Color _originalColor;

    private void Start()
    {
        _image = GetComponent<Image>();
        _originalColor = _image.color;
        _transform = transform;
        _originSize = transform.localScale.x;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _transform.DOScale(_originSize - _minSize, _duration);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _transform.DOScale(_originSize + _maxSize, _duration);
        _image.DOColor(_color,_duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _transform.DOScale(_originSize , _duration);
        _image.DOColor(_originalColor, _duration);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_transform.DOScale(_originSize, _duration));
        sequence.Join(_image.DOColor(_originalColor, _duration));
        sequence.OnComplete(() =>
        {
            _uiСontroller.ButtonPress(_buttonType);
        });
    }
}
