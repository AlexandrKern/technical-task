using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Класс для асинхронной загрузки данных при старте игры.
/// </summary>
public class DataLoader : MonoBehaviour
{
    [SerializeField] private DataSaver _dataSaver;
    [SerializeField] private BaseFigureList _baseFigureList;

    private async void Start()
    {
        await LoadDataListAsync();
    }

    /// <summary>
    /// Асинхронная загрузка списка данных.
    /// </summary>
    /// <returns>UniTask</returns>
    public async UniTask LoadDataListAsync()
    {
        string path = Path.Combine(Application.persistentDataPath, "InventoryData.json");

        if (File.Exists(path))
        {
            await LoadData(path);// Если файл существует, загрузить данные
        }
        else
        { 
            // Если файл не существует, сбросить данные к дефолтным значениям и сохранить их
            ResetDataToDefault();
            _dataSaver.SavePlayerDataList();
            await UniTask.DelayFrame(1);
            
            await LoadData(path); // Загрузить данные после сохранения дефолтных значений
        }
    }

    /// <summary>
    /// Сбрасывает данные к значениям по умолчанию.
    /// </summary>
    private void ResetDataToDefault()
    {
        foreach (var figureData in _baseFigureList.baseFigures)
        {
            // Находит соответствующую базовую фигуру по имени и сбрасывает её данные
            BaseFigure baseFigure = _baseFigureList.baseFigures.Find(bf => bf.figureName == figureData.figureName);
            baseFigure.ResetData(figureData);
        }
    }

    /// <summary>
    /// Класс-обертка для десериализации списка данных.
    /// </summary>
    /// <typeparam name="T">Тип данных</typeparam>
    [System.Serializable]
    private class Wrapper<T>
    {
        public T items;
    }

    /// <summary>
    /// Асинхронная загрузка данных из файла.
    /// </summary>
    /// <param name="path">Путь к файлу данных</param>
    /// <returns>UniTask</returns>
    private async UniTask LoadData(string path)
    {
        string json = await UniTask.Run(() => File.ReadAllText(path));

        List<FigureData> figureDatas = JsonUtility.FromJson<Wrapper<List<FigureData>>>(json).items;

        foreach (var figureData in figureDatas)
        {
            // Находит соответствующую базовую фигуру по имени и загружает её данные
            BaseFigure baseFigure = _baseFigureList.baseFigures.Find(bf => bf.figureName == figureData.figureName);
            baseFigure.LoadData(figureData);
        }
    }
}
