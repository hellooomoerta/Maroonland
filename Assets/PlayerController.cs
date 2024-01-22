using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public PlayerAnimationScript playerAnimation;
    public InputActionReference move;
    public InputActionReference look;
    public InputActionReference fire;
    public WeaponScript weapon;
    public Crosshair crosshair;
    private Vector2 _moveInput;

    private void OnEnable()
    {
        fire.action.started += _ => weapon.FireStarted();
        fire.action.canceled += _ => weapon.FireCancelled();
        look.action.started += _ => weapon.SetCrosshairPosition(crosshair.transform.position);
    }

    private void Update()
    {
        _moveInput = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(_moveInput.x * moveSpeed, _moveInput.y * moveSpeed);
        playerAnimation.SetMovement(_moveInput);
        weapon.SetPlayerPosition(transform.position);
    }
}
