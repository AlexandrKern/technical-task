using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������� ���������, ����������� ������������ ��������� �����.
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
    /// ��������� ��������� ���������, �������� ����� ��������� ������ � ������ �������������.
    /// </summary>
    public void UpdateInventoryUI()
    {
        foreach (BaseFigure baseFigure in _list.baseFigures)
        {
            if (baseFigure.isCollected)
            {
                // ���� ������ �������, �� � ��� � ����� ���������, ������� ����� ����
                if (!_inventorySlots.ContainsKey(baseFigure))
                {
                    GameObject slot = Instantiate(_inventorySlotPrefab, _inventoryPanel.transform);
                    _inventorySlots[baseFigure] = slot;
                }

                // ��������� ������ � ����� ���������
                GameObject existingSlot = _inventorySlots[baseFigure];
                existingSlot.transform.Find("icon").GetComponent<Image>().sprite = baseFigure.icon;
                existingSlot.transform.Find("figureQuantity").GetComponent<Text>().text = baseFigure.figureQuantity.ToString();
                existingSlot.transform.Find("figureDiscription").GetComponent<Text>().text = baseFigure.figureDescription;
                existingSlot.transform.Find("figureName").GetComponent<Text>().text = baseFigure.figureName;
            }
        }

        // ������ �����, ������� ����� ������� �� ���������
        List<BaseFigure> figuresToRemove = new List<BaseFigure>();

        // ������� ����� ��� �����, ������� ������ �� �������
        foreach (var entry in _inventorySlots)
        {
            if (!entry.Key.isCollected)
            {
                Destroy(entry.Value);
                figuresToRemove.Add(entry.Key);
            }
        }

        // ������� ������ �� ������� ��� ��������� �����
        foreach (BaseFigure figure in figuresToRemove)
        {
            _inventorySlots.Remove(figure);
        }
    }
}
