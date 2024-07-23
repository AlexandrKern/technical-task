using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// ����� ��� ���������� ��������� �������� ������ ������.
/// </summary>
public class CollectibleIconAnimator : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private RectTransform _imageRect;
    [SerializeField] private float _duration = 2f; 

    private Vector3 _originalPosition;
    private Vector3 _originalScale;

    private void Start()
    {
        _originalPosition = transform.position;
        _originalScale = transform.localScale;
    }

    /// <summary>
    /// ����� ��� �������� �������� ������ ������.
    /// </summary>
    public void Animate(BaseFigure baseFigure)
    {
        gameObject.SetActive(true);
        _image.sprite = baseFigure.icon;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0, _duration));
        sequence.Join(transform.DOMove(_targetPosition.position, _duration));
        sequence.OnComplete(Reset);
    }

    /// <summary>
    /// ����� ��� ������ ������� � �������� ������, � ����� ����������� �������.
    /// </summary>
    private void Reset()
    {
        transform.position = _originalPosition;
        transform.localScale = _originalScale;
        gameObject.SetActive(false);
    }
}
