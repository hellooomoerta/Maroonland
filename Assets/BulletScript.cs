using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject bloodSplash;
    public float damage;
    internal Wielder WeaponWielder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PlayerBulletHasCollidedWithEnemy(collision) && !EnemyBulletHasCollidedWithPlayer(collision))
        {
            return;
        }
        
        Destroy(gameObject);
        Instantiate(bloodSplash, transform.position, transform.rotation);
        collision.gameObject.SendMessage("TakeDamage", damage);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private bool PlayerBulletHasCollidedWithEnemy(Collider2D collision) => WeaponWielder == Wielder.Player && collision.gameObject.CompareTag("Enemy");

    private bool EnemyBulletHasCollidedWithPlayer(Collider2D collision) => WeaponWielder == Wielder.Enemy && collision.gameObject.CompareTag("Player");
}
