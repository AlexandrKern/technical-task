using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс для управления сменой сцен.
/// </summary>
public class SceneController : MonoBehaviour
{
    /// <summary>
    /// Загрузка сцены по индексу.
    /// </summary>
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
