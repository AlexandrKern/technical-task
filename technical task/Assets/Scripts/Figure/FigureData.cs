using System;
using UnityEngine;

/// <summary>
/// �����, �������������� ������ ������.
/// </summary>
[Serializable]
public class FigureData
{
    /// <summary>
    /// ���������� �����.
    /// </summary>
    public int figureQuantity;

    /// <summary>
    /// ��� ������.
    /// </summary>
    public string figureName;

    /// <summary>
    /// �������� ������.
    /// </summary>
    public string figureDescription;

    /// <summary>
    /// ����, �����������, ������� �� ������.
    /// </summary>
    public bool isCollected;

    /// <summary>
    /// ������ ������.
    /// </summary>
    public Sprite icon;
}
