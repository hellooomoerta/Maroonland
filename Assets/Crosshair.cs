using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
    private Vector2 _mousePosition;
    
    private void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(_mousePosition.x, _mousePosition.y, -1);
    }
}
