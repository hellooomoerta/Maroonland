using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision) 
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
