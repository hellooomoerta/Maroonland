using UnityEngine;

internal enum MovementState
{
    Idle,
    Down,
    Up,
    DiagonalUp,
    DiagonalDown,
    Horizontal 
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
            case MovementState.Down:
                animator.SetBool("isMoving", true);
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", -1);
                break;
            case MovementState.Up:
                animator.SetBool("isMoving", true);
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", 1);
                break;
            case MovementState.DiagonalDown:
                animator.SetBool("isMoving", true);
                animator.SetFloat("moveX", 1);
                animator.SetFloat("moveY", -1);
                break;
            case MovementState.DiagonalUp:
                animator.SetBool("isMoving", true);
                animator.SetFloat("moveX", 1);
                animator.SetFloat("moveY", 1);
                break;
            case MovementState.Horizontal:
                animator.SetBool("isMoving", true);
                animator.SetFloat("moveX", 1);
                animator.SetFloat("moveY", 0);
                break;
        }
    }

    public void SetMovement(Vector2 movement)
    {
        SetSpriteLocalScale(movement);
        _movementState = (movement.x, movement.y) switch
        {
            (x: 0, y: > 0) => MovementState.Up,
            (x: 0, y: < 0) => MovementState.Down,
            (x: not 0, y: 0) => MovementState.Horizontal,
            (x: not 0, y: > 0) => MovementState.DiagonalUp,
            (x: not 0, y: < 0) => MovementState.DiagonalDown,
            _ => MovementState.Idle
        };
    }
    
    private void SetSpriteLocalScale(Vector2 movement)
    {
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }
}
