using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

internal enum MovementState
{
    Idle,
    //Right,
    //DownRight,
    Down,
    //DownLeft,
    //Left,
    //UpLeft,
    Up,
    //UpRight
    DiagonalUp,     //Testar grejer
    DiagonalDown,   //Testar grejer
    Horizontal      //Testar grejer
}

public class PlayerAnimationScript : MonoBehaviour
{
    public Animator animator;
    public PlayerController playerController;
    private MovementState _movementState;

    private void Update()
    {
        SetSpriteLocalScale();

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

    void SetSpriteLocalScale()
    {
        if (playerController.rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (playerController.rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void SetMovement(Vector2 movement)
    {
        if (movement.y > 0) //Up
        {
            if (Mathf.Abs(movement.x) > 0) //Diagonal Up Right or Diagonal Up Left
            {
                _movementState = MovementState.DiagonalUp;
            }
            else
            {
                _movementState = MovementState.Up; //Neutral x
            }
        }
        else if (movement.y < 0) //Down
        {
            if (Mathf.Abs(movement.x) > 0) //Diagonal Down Right or Diagonal Down Left
            {
                _movementState = MovementState.DiagonalDown;
            }
            else
            {
                _movementState = MovementState.Down; //Neutral x
            }
        }
        else if (movement.y == 0)
        {
            if (Mathf.Abs(movement.x) > 0)
            {
                _movementState = MovementState.Horizontal; //Right or Left
            }
            else
            {
                _movementState = MovementState.Idle;
            }
        }
    }
}
