using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

/// <summary>
/// Компонент, управляющий движением игрока.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _turnSpeed = 10f;

    private CancellationTokenSource _cancellationTokenSource;
    private Rigidbody _rb;

    void Start()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _rb = GetComponent<Rigidbody>();
        PlayerMovementAsync(_cancellationTokenSource.Token).Forget();
    }

    /// <summary>
    /// Асинхронная задача, обеспечивающая движение игрока.
    /// </summary>
    private async UniTaskVoid PlayerMovementAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            // Проверяет, не на паузе ли игра
            if (!PauseController.isPaused)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");

                Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * _moveSpeed * Time.deltaTime;

                if (movement != Vector3.zero)
                {
                    _rb.MovePosition(_rb.position + movement);
                    // Рассчитывает и устанавливает новую ротацию
                    Quaternion newRotation = Quaternion.LookRotation(movement);
                    _rb.MoveRotation(Quaternion.Slerp(_rb.rotation, newRotation, _turnSpeed * Time.deltaTime));
                }
            }
     
            await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
        }
    }

    private void OnDestroy()
    {
        _cancellationTokenSource.Cancel();
    }
}
