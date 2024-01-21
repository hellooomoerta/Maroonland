using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    public Animator animator;
    public Transform transform;
    public Vector2 moveDirection;

    void Start()
    {
        
    }


    void Update()
    {
        if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void UpdateMovement(Vector2 movement)
    {
        animator.SetFloat("x", movement.x);
        animator.SetFloat("y", movement.y);

        moveDirection = movement;
    }
}
