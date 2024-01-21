using UnityEngine;

public class BulletSpawnPoint : MonoBehaviour
{
    private Vector3 _crosshairPosition;
    private Vector3 _playerPosition;
    private readonly float _playerOffset = 0.6f;

    public void UpdatePositions(Vector3 playerPosition, Vector3 crosshairPosition)
    {
        _playerPosition = playerPosition;
        _crosshairPosition = crosshairPosition;
    }
    
    private void Update()
    {
        var direction = (_crosshairPosition - _playerPosition).normalized;
        transform.position = _playerPosition + direction * _playerOffset;
    }
}
