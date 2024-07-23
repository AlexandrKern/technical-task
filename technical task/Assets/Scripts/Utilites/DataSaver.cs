using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// ����� ��� ���������� ������ ������ � JSON ����.
/// </summary>
public class DataSaver : MonoBehaviour
{
    [SerializeField] private BaseFigureList _figureList;

    /// <summary>
    /// ���������� ��������� ������ ������ ������ � JSON ����.
    /// </summary>
    /// <returns>UniTaskVoid</returns>
    public async UniTaskVoid SavePlayerDataList()
    {
        List<FigureData> playerDataList = new List<FigureData>();

        foreach (var playerDataSO in _figureList.baseFigures)
        {
            FigureData figureData = new FigureData
            {
                figureName = playerDataSO.figureName,
                figureDescription = playerDataSO.figureDescription,
                figureQuantity = playerDataSO.figureQuantity,
                isCollected = playerDataSO.isCollected
                
            };
            playerDataList.Add(figureData);
        }

        string json =  JsonUtility.ToJson(new Wrapper<List<FigureData>> { items = playerDataList },true);

        string filePath =  Path.Combine(Application.persistentDataPath, "InventoryData.json");

        await UniTask.Run(() => File.WriteAllText(filePath, json));
    }

    private void OnApplicationQuit()
    {
         SavePlayerDataList();
    }

    /// <summary>
    /// �����-������� ��� ������������ ������ ������.
    /// </summary>
    /// <typeparam name="T">��� ������</typeparam>
    [System.Serializable]
    private class Wrapper<T>
    {
        public T items;
    }
}
