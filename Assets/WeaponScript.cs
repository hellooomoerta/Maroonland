using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float playerOffset = 0.6f;
    public float bulletSpeed = 10f;
    public float weaponSpeed = 0.2f;
    public GameObject bulletPrefab;
    private Vector3 _playerPosition;
    private Vector3 _crosshairPosition;

    public void FireStarted() => InvokeRepeating("Shoot", 0f, weaponSpeed);
    
    public void FireCancelled() => CancelInvoke("Shoot");

    public void SetPlayerPosition(Vector3 position) => _playerPosition = position;
    
    public void SetCrosshairPosition(Vector3 position) => _crosshairPosition = position;

    private void Shoot()
    {
        var pointBetweenPlayerAndCrosshair = (_crosshairPosition - _playerPosition).normalized;
        var bulletSpawnPoint = _playerPosition + pointBetweenPlayerAndCrosshair * playerOffset;
        var pointBetweenSpawnPointAndCrosshair = _crosshairPosition - bulletSpawnPoint;
        
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint, Quaternion.identity);
        var rigidbody2d = bullet.GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = pointBetweenSpawnPointAndCrosshair.normalized * bulletSpeed;
    }
}
