using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject bloodSplash;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(bloodSplash, transform.position, transform.rotation);
            collision.gameObject.SendMessage("TakeDamage");
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
