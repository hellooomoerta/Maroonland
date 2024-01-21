using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float bulletSpeed = 10f;
    public Rigidbody2D rb;
    public BulletSpawnPoint bulletSpawnPoint;
    public Crosshair crosshair;
    public PlayerAnimationScript animation;
    public GameObject bulletPrefab;
    private PlayerInput _playerInput;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Player.Move.Enable();
        _playerInput.Player.Fire.Enable();

    }

    private void OnDisable()
    {
        _playerInput.Player.Move.Disable();
        _playerInput.Player.Fire.Disable();
    }

    private void Update()
    {
        UpdateBulletSpawnPoint();
        Move();
        Shoot();
    }

    private void UpdateBulletSpawnPoint()
    {
        bulletSpawnPoint.UpdatePositions(transform.position, crosshair.transform.position);
    }

    private void Move()
    {
        var movement = _playerInput.Player.Move.ReadValue<Vector2>();
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        animation.UpdateMovement(movement);
    }
    
    private void Shoot()
    {
        if (_playerInput.Player.Fire.triggered)
        {
            var spawnPoint = bulletSpawnPoint.transform.position;
            var direction = crosshair.transform.position - spawnPoint;
            var bullet = Instantiate(bulletPrefab, spawnPoint, Quaternion.identity);
            var rigidbody2d = bullet.GetComponent<Rigidbody2D>();
            rigidbody2d.velocity = direction.normalized * bulletSpeed;
        }
    }
}
