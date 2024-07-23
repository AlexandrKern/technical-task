using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// ����� ��� ����������� �������� ������ ��� ������ ����.
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
    /// ����������� �������� ������ ������.
    /// </summary>
    /// <returns>UniTask</returns>
    public async UniTask LoadDataListAsync()
    {
        string path = Path.Combine(Application.persistentDataPath, "InventoryData.json");

        if (File.Exists(path))
        {
            await LoadData(path);// ���� ���� ����������, ��������� ������
        }
        else
        { 
            // ���� ���� �� ����������, �������� ������ � ��������� ��������� � ��������� ��
            ResetDataToDefault();
            _dataSaver.SavePlayerDataList();
            await UniTask.DelayFrame(1);
            
            await LoadData(path); // ��������� ������ ����� ���������� ��������� ��������
        }
    }

    /// <summary>
    /// ���������� ������ � ��������� �� ���������.
    /// </summary>
    private void ResetDataToDefault()
    {
        foreach (var figureData in _baseFigureList.baseFigures)
        {
            // ������� ��������������� ������� ������ �� ����� � ���������� � ������
            BaseFigure baseFigure = _baseFigureList.baseFigures.Find(bf => bf.figureName == figureData.figureName);
            baseFigure.ResetData(figureData);
        }
    }

    /// <summary>
    /// �����-������� ��� �������������� ������ ������.
    /// </summary>
    /// <typeparam name="T">��� ������</typeparam>
    [System.Serializable]
    private class Wrapper<T>
    {
        public T items;
    }

    /// <summary>
    /// ����������� �������� ������ �� �����.
    /// </summary>
    /// <param name="path">���� � ����� ������</param>
    /// <returns>UniTask</returns>
    private async UniTask LoadData(string path)
    {
        string json = await UniTask.Run(() => File.ReadAllText(path));

        List<FigureData> figureDatas = JsonUtility.FromJson<Wrapper<List<FigureData>>>(json).items;

        foreach (var figureData in figureDatas)
        {
            // ������� ��������������� ������� ������ �� ����� � ��������� � ������
            BaseFigure baseFigure = _baseFigureList.baseFigures.Find(bf => bf.figureName == figureData.figureName);
            baseFigure.LoadData(figureData);
        }
    }
}
