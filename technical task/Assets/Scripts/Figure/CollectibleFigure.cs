using UnityEngine;

/// <summary>
/// ��������� ������ ����� �������.
/// </summary>
public class CollectibleFigure : MonoBehaviour
{
    [SerializeField] private InventoryController _inventoryController;
    [SerializeField] private BaseFigure _baseFigure;
    [SerializeField] private CollectibleIconAnimator _raisedFigure;

    private  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             Collect();
        }
    }

    /// <summary>
    /// ��������� �������� �� ����� ������.
    /// </summary>
    private void Collect()
    {
        _baseFigure.isCollected = true;
        _baseFigure.figureQuantity++;
        _inventoryController.UpdateInventoryUI();
        _raisedFigure.Animate(_baseFigure);
        Destroy(gameObject);
    }
}
