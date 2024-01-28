using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public PlayerAnimationScript playerAnimation;
    public InputActionReference move;
    public InputActionReference lookMouse;
    public InputActionReference lookGamepad;
    public InputActionReference fire;
    public WeaponScript weapon;
    private Vector2 _moveInput;

    private void OnEnable()
    {
        fire.action.started += _ => weapon.FireStarted();
        fire.action.canceled += _ => weapon.FireCancelled();
        lookMouse.action.performed += _ => weapon.OnMouseMove();
        lookGamepad.action.performed += x => weapon.OnGamepadMove(x.ReadValue<Vector2>());
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
    }
}
