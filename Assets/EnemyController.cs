using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    enum CharacterState
    {
        Moving,
        Aiming,
        Shooting
    }
    
    public GameObject player;
    public float moveSpeed = 5f;
    public float range = 7f;
    public float aimDuration = 0.05f;
    public float shootDuration = 0.2f;
    public float moveDuration = 0.3f;
    public Rigidbody2D rb;
    public PlayerAnimationScript playerAnimation;
    public WeaponScript weapon;
    private Vector2 _moveDirection = Vector2.zero;
    private Vector2 _playerDirection = Vector2.zero;
    private CharacterState _currentState = CharacterState.Moving;
    private bool _isPerformingAction = false;
    
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
        if (_isPerformingAction)
        {
            return;
        }
        
        switch (_currentState)
        {
            case CharacterState.Moving:
                Move();
                if (IsWithinRange())
                {
                    StartCoroutine(TransitionTo(CharacterState.Aiming, aimDuration));
                    break;
                }
                StartCoroutine(TransitionTo(CharacterState.Moving, moveDuration));
                break;
            case CharacterState.Aiming:
                Aim();
                StartCoroutine(TransitionTo(CharacterState.Shooting, shootDuration));
                break;
            case CharacterState.Shooting:
                Shoot();
                StartCoroutine(TransitionTo(CharacterState.Moving, moveDuration));
                break;
        }
    }

    private IEnumerator TransitionTo(CharacterState state, float duration)
    {
        _isPerformingAction = true;
        yield return new WaitForSeconds(duration);
        _currentState = state;
        _isPerformingAction = false;
    }
    
    private void Move()
    {
        rb.velocity = _moveDirection * moveSpeed;
        playerAnimation.SetMovement(_moveDirection);
    }

    private bool IsWithinRange()
    {
        var position = transform.position;
        var hit = Physics2D.Raycast(position, _playerDirection, range);
        
        return hit.collider is not null && hit.collider.CompareTag("Player");
    }
    
    private void Aim()
    {
        weapon.OnGamepadMove(_playerDirection);
    }
    
    private void Shoot()
    {
        weapon.Fire();
    }
}
