using System;
using UnityEngine;

/// <summary>
/// Класс, представляющий данные фигуры.
/// </summary>
[Serializable]
public class FigureData
{
    /// <summary>
    /// Количество фигур.
    /// </summary>
    public int figureQuantity;

    /// <summary>
    /// Имя фигуры.
    /// </summary>
    public string figureName;

    /// <summary>
    /// Описание фигуры.
    /// </summary>
    public string figureDescription;

    /// <summary>
    /// Флаг, указывающий, собрана ли фигура.
    /// </summary>
    public bool isCollected;

    /// <summary>
    /// Иконка фигуры.
    /// </summary>
    public Sprite icon;
}
