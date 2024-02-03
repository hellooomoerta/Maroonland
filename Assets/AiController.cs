using UnityEngine;
using UnityEngine.InputSystem;

public class AiController : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public PlayerAnimationScript playerAnimation;
    public WeaponScript weapon;
    private Vector2 _direction;


    private void Update()
    {
        _direction = (player.transform.position - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        Move();
        Aim();
    }

    private void Aim()
    {
        weapon.OnGamepadMove(_direction);
    }

    private void Move()
    {
        rb.velocity = _direction * moveSpeed;
        playerAnimation.SetMovement(_direction);
    }
}
