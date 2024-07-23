/// <summary>
/// Класс для управления состоянием паузы игры.
/// </summary>
public static class PauseController 
{
    /// <summary>
    /// Состояние паузы игры.
    /// </summary>
    public static bool isPaused { get; private set; } = false;

    /// <summary>
    /// Переключает состояние паузы.
    /// </summary>
    public static void TogglePause()
    {
        isPaused = !isPaused;
    }
}
