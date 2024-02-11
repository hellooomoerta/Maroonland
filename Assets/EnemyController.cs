using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    public float range = 7f;
    public float fireRate = 1f;
    public Rigidbody2D rb;
    public PlayerAnimationScript playerAnimation;
    public WeaponScript weapon;
    private Vector2 _moveDirection = Vector2.zero;
    private Vector2 _playerDirection = Vector2.zero;
    private float _lastFiredTime;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        _playerDirection = (player.transform.position - transform.position).normalized;
        _moveDirection = IsWithinRange() ? Vector2.zero : _playerDirection;
    }

    private void FixedUpdate()
    {
        Move();
        if (IsWithinRange())
        {
            Aim();
            Shoot();
        }
    }
    
    private void Move()
    {
        rb.velocity = _moveDirection * moveSpeed;
        playerAnimation.SetMovement(_moveDirection);
    }

    private bool IsWithinRange()
    {
        var position = transform.position;
        var hit = Physics2D.Raycast(position, _playerDirection,Random.Range(range, range * 1.5f));
        
        return hit.collider is not null && hit.collider.CompareTag("Player");
    }
    
    private void Aim()
    {
        weapon.OnGamepadMove(_playerDirection);
    }
    
    private void Shoot()
    {
        if (Time.time - _lastFiredTime < fireRate)
        {
            return;
        }
        weapon.Fire();
        _lastFiredTime = Time.time;
    }
}
