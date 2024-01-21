using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float bulletSpeed = 10f;
    public float bulletSpawnOffset = 0.6f;
    public Rigidbody2D rb;
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
        Move();
        Shoot();
    }

    private void Move()
    {
        var movement = _playerInput.Player.Move.ReadValue<Vector2>();
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        animation.UpdateMovement(movement);
    }
    
    private void Shoot()
    {
        if (!_playerInput.Player.Fire.triggered)
        {
            return;
        }

        var playerPosition = transform.position;
        var direction = (playerPosition - crosshair.transform.position).normalized;
        var spawnPoint = playerPosition + direction * bulletSpawnOffset;
        var offset = playerPosition - spawnPoint;
        var bullet = Instantiate(bulletPrefab, spawnPoint + offset.normalized, Quaternion.identity);
        var rigidbody2d = bullet.GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = offset.normalized * bulletSpeed;
    }
}
