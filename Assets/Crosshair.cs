using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Player.Look.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Player.Look.Disable();
    }

    private void Update()
    {
        var position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = new Vector3(position.x, position.y, -1);
    }
}
