using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Класс для управления анимацией и отображением описания иконки в инвентаре.
/// </summary>
public class SlotInventoryController : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private float _minSize = 0.1f;
    [SerializeField] private float _maxSize = 0.1f;
    [SerializeField] private Text _textDescription;

    private float _originSize;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _originSize = transform.localScale.x;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _transform.DOScale(_originSize + _maxSize, _duration);
        _textDescription.gameObject.SetActive(true);
        _textDescription.transform.DOScale(_originSize + _maxSize, _duration).SetLoops(-1, LoopType.Yoyo);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _transform.DOScale(_originSize, _duration);
        _textDescription.transform.DOKill();
        _textDescription.transform.localScale = Vector3.one * _originSize;
        _textDescription.gameObject.SetActive(false);
    }

}
