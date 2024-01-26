using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    public float playerOffset = 0.6f;   
    public float bulletSpeed = 800f;
    public float weaponSpeed = 0.2f;
    public GameObject bulletPrefab;

    public void FireStarted() => InvokeRepeating("Shoot", 0f, weaponSpeed);
    
    public void FireCancelled() => CancelInvoke("Shoot");

    public void UpdatePosition(Vector3 position) => transform.position = position;

    public void UpdateAim(Vector2 position)
    {
        if (position.magnitude > 0.1f)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            var direction = mousePosition - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, transform.position + transform.right * playerOffset, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
    }
}
