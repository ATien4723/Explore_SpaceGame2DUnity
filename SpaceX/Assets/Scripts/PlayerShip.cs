using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float forwardForce = 8f;
    [SerializeField] float sideForce = 2f;
    [SerializeField] float sideIncrement = 2f;
    public GameObject poofParticle;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] AudioClip deathSFX;  // Âm thanh khi nhân vật chết
    [SerializeField] AudioSource audioSource;  // AudioSource để phát âm thanh

    Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = transform.position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyShip enemy = collision.collider.GetComponent<EnemyShip> ();
        if ( enemy != null ) {
            Instantiate (poofParticle, transform.position, Quaternion.identity); // Tạo hiệu ứng nổ tại vị trí của tàu
            Destroy (gameObject);
            PlayDeathSound ();  // Chơi âm thanh chết

            Destroy (enemy.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMove = Input.GetAxis ("Vertical");
        float horizontalMove = Input.GetAxis ("Horizontal");
        horizontalMove *= sideIncrement;  // Apply sideIncrement here
        Vector3 movementVector = new Vector3 (horizontalMove * forwardForce, verticalMove * sideForce, 0);
        movementVector *= Time.deltaTime;
        transform.Translate (movementVector);

        if ( transform.position.y >= 5 ||
            transform.position.y <= -5 ) {
            transform.position = new Vector3 (transform.position.x, _initialPosition.y, 0);
        }
    }

    public void TakeDamage()
    {
        UnityEngine.Debug.Log ("Player Hit");
        Instantiate (poofParticle, transform.position, Quaternion.identity);
        PlayDeathSound ();  // Chơi âm thanh chết

        GameSession.Instance.ProcessPlayerDeath ();
        Destroy (gameObject);
    }

    private void PlayDeathSound()
    {
        if ( deathSFX != null ) {
            audioSource.PlayOneShot (deathSFX);  // Phát âm thanh khi chết
        }
    }
}
