using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
/// ���������� ������ ��������� �� ������� � ������� ���������.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;

    private CancellationTokenSource _cancellationTokenSource;

    void Start()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _offset = transform.position - _player.position;// ���������� ���������� �������� ������ ������������ ������
        CameraMovementAsync(_cancellationTokenSource.Token).Forget();
    }

    /// <summary>
    /// ����������� ������, �������������� ������� �������� ������ �� �������.
    /// </summary>
    private async UniTaskVoid CameraMovementAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Vector3 desiredPosition = _player.position + _offset; // �������� ������� ������ � ������ ��������

            // ������� �������� ������ � �������� �������
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 2);
            transform.position = smoothedPosition;

            // ���������� ������� ������� ������, ����� �������� �� ������
            Quaternion targetRotation = Quaternion.LookRotation(_player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2);

            // �������� �� ���������� �����
            await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
        }
    }

    private void OnDestroy()
    {
        _cancellationTokenSource.Cancel();
    }
}
