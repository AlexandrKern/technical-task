using DG.Tweening;
using UnityEngine;

/// <summary>
/// Класс для управления анимацией открытия и закрытия инвентаря.
/// </summary>
public class OpenInvetoryAnimation : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _duration = 2f;

    private Vector3 _originalPosition;
    private Vector3 _originalScale;
    private bool _isOpen;

    private void Start()
    {
        _originalPosition = transform.position;
        _originalScale = transform.localScale;
        _isOpen = false;
    }

    /// <summary>
    /// Переключает состояние инвентаря.
    /// </summary>
    public void ToggleInventory()
    {
        if (!_isOpen)
        {
            OpenInventory();
        }
        else
        {
            CloseInventory();
        }
        _isOpen = !_isOpen;
    }

    /// <summary>
    /// Открывает инвентарь с анимацией.
    /// </summary>
    private void OpenInventory()
    {
        gameObject.SetActive(true);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector3(1.5f,1.5f,1.5f), _duration));
        sequence.Join(transform.DOMove(_targetPosition.position, _duration));
    }

    /// <summary>
    /// Закрывает инвентарь с анимацией.
    /// </summary>
    private void CloseInventory()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(_originalScale, _duration));
        sequence.Join(transform.DOMove(_originalPosition, _duration));
        sequence.OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
