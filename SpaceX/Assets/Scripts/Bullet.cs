using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    [SerializeField] Rigidbody2D rb;
    public GameObject poofParticle;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed * 4;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Debug.Log("Player Bullet collided with " + collision.name);

        AsteroidCollision asteroid = collision.GetComponent<AsteroidCollision>();
        Enemy2 enemy = collision.GetComponent<Enemy2> ();
        if (asteroid != null)
        {
            Debug.Log("Asteroid Hit by Player Bullet");
            Instantiate(poofParticle, transform.position, Quaternion.identity);
            asteroid.TakeDamage();
        }
        else if (enemy != null)
        {
            Debug.Log("Enemy hit by Player Bullet");
            Instantiate(poofParticle, transform.position, Quaternion.identity);
            enemy.TakeDamage();
        }
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
