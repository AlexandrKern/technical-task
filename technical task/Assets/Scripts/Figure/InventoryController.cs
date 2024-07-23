using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Контроллер инвентаря, управляющий отображением собранных фигур.
/// </summary>
public class InventoryController : MonoBehaviour
{
    [SerializeField] private BaseFigureList _list;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private GameObject _inventorySlotPrefab;

    private Dictionary<BaseFigure, GameObject> _inventorySlots = new Dictionary<BaseFigure, GameObject>();

    private void Start()
    {
        UpdateInventoryUI();
    }

    /// <summary>
    /// Обновляет интерфейс инвентаря, добавляя новые собранные фигуры и удаляя отсутствующие.
    /// </summary>
    public void UpdateInventoryUI()
    {
        foreach (BaseFigure baseFigure in _list.baseFigures)
        {
            if (baseFigure.isCollected)
            {
                // Если фигура собрана, но её нет в слоте инвентаря, создает новый слот
                if (!_inventorySlots.ContainsKey(baseFigure))
                {
                    GameObject slot = Instantiate(_inventorySlotPrefab, _inventoryPanel.transform);
                    _inventorySlots[baseFigure] = slot;
                }

                // Обновляет данные в слоте инвентаря
                GameObject existingSlot = _inventorySlots[baseFigure];
                existingSlot.transform.Find("icon").GetComponent<Image>().sprite = baseFigure.icon;
                existingSlot.transform.Find("figureQuantity").GetComponent<Text>().text = baseFigure.figureQuantity.ToString();
                existingSlot.transform.Find("figureDiscription").GetComponent<Text>().text = baseFigure.figureDescription;
                existingSlot.transform.Find("figureName").GetComponent<Text>().text = baseFigure.figureName;
            }
        }

        // Список фигур, которые нужно удалить из инвентаря
        List<BaseFigure> figuresToRemove = new List<BaseFigure>();

        // Удаляет слоты для фигур, которые больше не собраны
        foreach (var entry in _inventorySlots)
        {
            if (!entry.Key.isCollected)
            {
                Destroy(entry.Value);
                figuresToRemove.Add(entry.Key);
            }
        }

        // Удаляет записи из словаря для удаленных фигур
        foreach (BaseFigure figure in figuresToRemove)
        {
            _inventorySlots.Remove(figure);
        }
    }
}
