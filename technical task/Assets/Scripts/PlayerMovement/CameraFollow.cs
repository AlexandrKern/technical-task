using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
/// «аставл€ет камеру следовать за игроком с плавным движением.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;

    private CancellationTokenSource _cancellationTokenSource;

    void Start()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _offset = transform.position - _player.position;// ¬ычисление начального смещени€ камеры относительно игрока
        CameraMovementAsync(_cancellationTokenSource.Token).Forget();
    }

    /// <summary>
    /// јсинхронна€ задача, обеспечивающа€ плавное движение камеры за игроком.
    /// </summary>
    private async UniTaskVoid CameraMovementAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Vector3 desiredPosition = _player.position + _offset; // ∆елаема€ позици€ камеры с учетом смещени€

            // ѕлавное движение камеры к желаемой позиции
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 2);
            transform.position = smoothedPosition;

            // ¬ычисление целевой ротации камеры, чтобы смотреть на игрока
            Quaternion targetRotation = Quaternion.LookRotation(_player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2);

            // ќжидание до следующего кадра
            await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
        }
    }

    private void OnDestroy()
    {
        _cancellationTokenSource.Cancel();
    }
}
