using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.gameObject.SendMessage("TakeDamage");
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
