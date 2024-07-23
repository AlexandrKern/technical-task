using UnityEngine;

/// <summary>
/// ScriptableObject, �������������� ������� ������.
/// </summary>
[CreateAssetMenu(fileName = "Figure", menuName = "New figure")]
public class BaseFigure : ScriptableObject
{
    /// <summary>
    /// ���������� �����.
    /// </summary>
    [HideInInspector] public int figureQuantity;

    /// <summary>
    /// ����, �����������, ������� �� ������.
    /// </summary>
    [HideInInspector] public bool isCollected;

    /// <summary>
    /// ��� ������.
    /// </summary>
    public string figureName;

    /// <summary>
    /// �������� ������.
    /// </summary>
    public string figureDescription;

    /// <summary>
    /// ������ ������.
    /// </summary>
    public Sprite icon;

    /// <summary>
    /// ��������� ������ � ������� ������ �� �������.
    /// </summary>
    public void LoadData(FigureData figureData)
    {
        figureDescription = figureData.figureDescription;
        figureName = figureData.figureName; 
        figureQuantity = figureData.figureQuantity;
        isCollected = figureData.isCollected;
    }

    /// <summary>
    /// ���������� ������ ������� ������ � ��������� �� ���������.
    /// </summary>
    public void ResetData(BaseFigure baseFigure)
    {
        figureDescription = baseFigure.figureDescription;
        figureName = baseFigure.figureName;
        figureQuantity = 0;
        isCollected = false;
    }
}
