using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ����� ��� ���������� ������ ����.
/// </summary>
public class SceneController : MonoBehaviour
{
    /// <summary>
    /// �������� ����� �� �������.
    /// </summary>
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
