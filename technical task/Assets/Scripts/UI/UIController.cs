using UnityEngine;
using DG.Tweening;

/// <summary>
/// Класс для управления UI панелями и обработки нажатий кнопок.
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField] private OpenInvetoryAnimation _invetoryAnimation;
    [SerializeField] private  SceneController _sceneController;
    [SerializeField] private GameObject _pausePanel,_gamePanel,_inventoryPanel;
    [SerializeField] private DataSaver _dataSaver;

    /// <summary>
    /// Обрабатывает нажатие кнопок.
    /// </summary>
    public void ButtonPress(ButtonType buttonType)
    {
        switch (buttonType)
        {
            case ButtonType.Play:
                _sceneController.LoadSceneByIndex(1);
                break;
            case ButtonType.Pause:
                ChangePanel(_pausePanel, _gamePanel);
                PauseController.TogglePause();
                break;
            case ButtonType.Exit:
                _dataSaver.SavePlayerDataList();
                _sceneController.LoadSceneByIndex(0);
                PauseController.TogglePause();
                break;
            case ButtonType.Inventory:
                _invetoryAnimation.ToggleInventory();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Переключает видимость панели паузы и игровой панели
    /// </summary>
    private void ChangePanel(GameObject pausePanel, GameObject gamePanel)
    {
        if (pausePanel != null && gamePanel != null)
        {
            bool isPausePanelActive = pausePanel.activeInHierarchy;
            pausePanel.SetActive(!isPausePanelActive);
            gamePanel.SetActive(isPausePanelActive);
        }
    }

    private void OnDisable()
    {
        DOTween.KillAll();
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
