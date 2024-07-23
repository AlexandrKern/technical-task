/// <summary>
/// ����� ��� ���������� ���������� ����� ����.
/// </summary>
public static class PauseController 
{
    /// <summary>
    /// ��������� ����� ����.
    /// </summary>
    public static bool isPaused { get; private set; } = false;

    /// <summary>
    /// ����������� ��������� �����.
    /// </summary>
    public static void TogglePause()
    {
        isPaused = !isPaused;
    }
}
