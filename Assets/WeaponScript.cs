using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Wielder
{
    Player,
    Enemy
}

public class WeaponScript : MonoBehaviour
{
    public float playerOffset = 1f;   
    public float bulletSpeed = 800f;
    public float weaponSpeed = 0.2f;
    public bool rapidFire;
    public GameObject bulletPrefab;
    public Wielder WeaponWielder;
    
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
            InvokeRepeating(nameof(Shoot), 0f, weaponSpeed);
        }
    }

    public void RapidFireCancelled()
    {
        if (rapidFire)
        {
            CancelInvoke(nameof(Shoot));
        }
    }

    public void OnMouseMove()
    {
        var mousePosition = Camera.main!.ScreenToWorldPoint(Mouse.current.position.ReadValue());
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
        var script = bullet.GetComponent<BulletScript>();
        script.WeaponWielder = WeaponWielder;
        script.damage = 3;
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
    }
}
