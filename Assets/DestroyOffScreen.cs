using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private float _offset = 300f;
    private void Update()
    {
        var screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (IsOffScreen(screenPosition.x, Screen.width) || IsOffScreen(screenPosition.y, Screen.height))
        {
            Destroy(gameObject);
        }
    }

    private bool IsOffScreen(float position, int size)
    {
        return position > size + _offset || position < _offset;
    }
}
