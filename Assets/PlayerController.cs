using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private PlayerInput _playerInput;
    public PlayerAnimationScript animation;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Player.Move.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Player.Move.Disable();
    }

    private void FixedUpdate()
    {
        var movement = _playerInput.Player.Move.ReadValue<Vector2>();
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

        animation.UpdateMovement(movement);
    }
}
