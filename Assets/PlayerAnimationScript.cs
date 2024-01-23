using UnityEngine;

internal enum MovementState
{
    Idle,
    Right,
    DownRight,
    Down,
    DownLeft,
    Left,
    UpLeft,
    Up,
    UpRight
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
            case MovementState.Right:
                animator.SetBool("isMoving", true);
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                animator.SetFloat("moveX", 1);
                animator.SetFloat("moveY", 0);
                break;
            case MovementState.DownRight:
                animator.SetBool("isMoving", true);
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                animator.SetFloat("moveX", 0.71f);
                animator.SetFloat("moveY", -0.71f);
                break;
            case MovementState.Down:
                animator.SetBool("isMoving", true);
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", -1);
                break;
            case MovementState.DownLeft:
                animator.SetBool("isMoving", true);
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                animator.SetFloat("moveX", -0.71f);
                animator.SetFloat("moveY", -0.71f);
                break;
            case MovementState.Left:
                animator.SetBool("isMoving", true);
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                animator.SetFloat("moveX", -1);
                animator.SetFloat("moveY", 0);
                break;
            case MovementState.UpLeft:
                animator.SetBool("isMoving", true);
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                animator.SetFloat("moveX", -0.71f);
                animator.SetFloat("moveY", 0.71f);
                break;
            case MovementState.Up:
                animator.SetBool("isMoving", true);
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", 1);
                break;
            case MovementState.UpRight:
                animator.SetBool("isMoving", true);
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                animator.SetFloat("moveX", 0.71f);
                animator.SetFloat("moveY", 0.71f);
                break;
        }
    }

    public void SetMovement(Vector2 movement)
    {
        if (movement.x == 0 && movement.y == 0)
        {
            _movementState = MovementState.Idle;
        }
        else if (movement.x == 1 && movement.y == 0)
        {
            _movementState = MovementState.Right;
        }
        else if (movement.x == 1 && movement.y == -1)
        {
            _movementState = MovementState.DownRight;
        }
        else if (movement.x == 0 && movement.y == -1)
        {
            _movementState = MovementState.Down;
        }
        else if (movement.x == -1 && movement.y == -1)
        {
            _movementState = MovementState.DownLeft;
        }
        else if (movement.x == -1 && movement.y == 0)
        {
            _movementState = MovementState.Left;
        }
        else if (movement.x == -1 && movement.y == 1)
        {
            _movementState = MovementState.UpLeft;
        }
        else if (movement.x == 0 && movement.y == 1)
        {
            _movementState = MovementState.Up;
        }
        else if (movement.x == 1 && movement.y == 1)
        {
            _movementState = MovementState.UpRight;
        }
    }
}
