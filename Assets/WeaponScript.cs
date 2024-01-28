using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    public float playerOffset = 0.6f;   
    public float bulletSpeed = 800f;
    public float weaponSpeed = 0.2f;
    public bool rapidFire = false;
    public GameObject bulletPrefab;

    public void Fire()
    {
        if (!rapidFire)
        {
            Shoot();
        }
    }

    public void RapidFireStarted()
    {
        if (rapidFire)
        {
            InvokeRepeating("Shoot", 0f, weaponSpeed);
        }
    }

    public void RapidFireCancelled()
    {
        if (rapidFire)
        {
            CancelInvoke("Shoot");
        }
    }

    public void OnMouseMove()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Aim(mousePosition - transform.position);
    }
    
    public void OnGamepadMove(Vector2 direction)
    {
        if (direction.sqrMagnitude is 0) return;
        Aim(direction);
    }

    private void Aim(Vector3 direction)
    {
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, transform.position + transform.right * playerOffset, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
    }
}
