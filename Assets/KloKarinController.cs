using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KloKarinController : MonoBehaviour
{
    enum KloKarinState
    {
        Idling,
        Moving, 
        Running,
        Attacking,
        Dying
    }

    public Rigidbody2D rb;

    [SerializeField] private GameObject player;
    private bool _isPerformingAction = false;
    private Vector2 _moveDirection = Vector2.zero;
    private Vector2 _playerDirection = Vector2.zero;
    private KloKarinState _kloKarinState = KloKarinState.Idling;

    [SerializeField] private float aggroRange;
    [SerializeField] private float lungeAttackRange;
    [SerializeField] float runSpeed = 1f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        _playerDirection = (player.transform.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        if (_isPerformingAction)
        {
            return;
        }

        switch (_kloKarinState)
        {
            case KloKarinState.Idling:
                SwitchState();
                break;
            case KloKarinState.Moving:
                break;
            case KloKarinState.Running: 
                break;
            case KloKarinState.Attacking:
                break;
            case KloKarinState.Dying:
                break;
        }

        Debug.Log(_kloKarinState);
    }

    private IEnumerator TransitionTo(KloKarinState state, float duration)
    {
        _isPerformingAction = true;
        yield return new WaitForSeconds(duration);
        _kloKarinState = state;
        _isPerformingAction = false;
    }

    private void Move()
    {
        rb.velocity = _moveDirection * runSpeed;
    }

    private void SwitchState()
    {
        if (_kloKarinState == KloKarinState.Idling)
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= aggroRange)
            {
                _kloKarinState = KloKarinState.Running;
            }
        }
        if (_kloKarinState == KloKarinState.Moving)
        {

        }
        if (_kloKarinState == KloKarinState.Running)
        {

        }
        if (_kloKarinState == KloKarinState.Attacking)
        {

        }
        if (_kloKarinState == KloKarinState.Dying)
        {

        }
    }
}
