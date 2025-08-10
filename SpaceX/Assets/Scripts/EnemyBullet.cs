using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    [SerializeField] Rigidbody2D rb;
    public GameObject poofParticle;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed * 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Debug.Log("Enemy Bullet Contact with " + collision.name);

        PlayerShip playerShip = collision.GetComponent<PlayerShip>();
        Bullet bullet = collision.GetComponent<Bullet>();
        if (playerShip != null)
        {
            Instantiate(poofParticle, transform.position, Quaternion.identity);
            playerShip.TakeDamage();
        }
        else if (bullet != null)
        {
            bullet.TakeDamage();
        }
    }
}
