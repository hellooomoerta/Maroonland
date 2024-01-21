using UnityEngine;

internal enum MovementState
{
    Idle,
    Right,
    Left,
}

public class PlayerAnimationScript : MonoBehaviour
{
    public Animator animator;
    private MovementState _movementState;

    private void Update()
    {
        switch (_movementState)
        {
            case MovementState.Idle:
                animator.SetBool("isMoving", false);
            break;
            case MovementState.Left:
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isMoving", true);
                break;
            default:
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isMoving", true);
            break;
        }
    }

    public void UpdateMovement(Vector2 movement)
    {
        if (movement.x == 0 && movement.y == 0)
        {
            _movementState = MovementState.Idle;
        }
        else if (movement.x < 0)
        {
            _movementState = MovementState.Left;
        }
        else
        {
            _movementState = MovementState.Right;
        }
    }
}
