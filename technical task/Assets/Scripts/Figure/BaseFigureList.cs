using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject, представл€ющий список базовых фигур.
/// </summary>
[CreateAssetMenu(fileName = "Figure list", menuName = "New figure list")]
public class BaseFigureList : ScriptableObject
{
    /// <summary>
    /// —писок базовых фигур.
    /// </summary>
    public List<BaseFigure> baseFigures;
}
