using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject, �������������� ������ ������� �����.
/// </summary>
[CreateAssetMenu(fileName = "Figure list", menuName = "New figure list")]
public class BaseFigureList : ScriptableObject
{
    /// <summary>
    /// ������ ������� �����.
    /// </summary>
    public List<BaseFigure> baseFigures;
}
