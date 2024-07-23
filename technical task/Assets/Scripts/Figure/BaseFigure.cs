using UnityEngine;

/// <summary>
/// ScriptableObject, представляющий базовую фигуру.
/// </summary>
[CreateAssetMenu(fileName = "Figure", menuName = "New figure")]
public class BaseFigure : ScriptableObject
{
    /// <summary>
    /// Количество фигур.
    /// </summary>
    [HideInInspector] public int figureQuantity;

    /// <summary>
    /// Флаг, указывающий, собрана ли фигура.
    /// </summary>
    [HideInInspector] public bool isCollected;

    /// <summary>
    /// Имя фигуры.
    /// </summary>
    public string figureName;

    /// <summary>
    /// Описание фигуры.
    /// </summary>
    public string figureDescription;

    /// <summary>
    /// Иконка фигуры.
    /// </summary>
    public Sprite icon;

    /// <summary>
    /// Загружает данные в базовую фигуру из объекта.
    /// </summary>
    public void LoadData(FigureData figureData)
    {
        figureDescription = figureData.figureDescription;
        figureName = figureData.figureName; 
        figureQuantity = figureData.figureQuantity;
        isCollected = figureData.isCollected;
    }

    /// <summary>
    /// Сбрасывает данные базовой фигуры к значениям по умолчанию.
    /// </summary>
    public void ResetData(BaseFigure baseFigure)
    {
        figureDescription = baseFigure.figureDescription;
        figureName = baseFigure.figureName;
        figureQuantity = 0;
        isCollected = false;
    }
}
