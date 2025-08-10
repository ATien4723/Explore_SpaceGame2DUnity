using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidCollision : MonoBehaviour
{
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject poofParticle;
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] int scoreValue = 100;  // The points awarded for destroying this asteroid

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.collider.GetComponent<PlayerShip> () ) {
            UnityEngine.Debug.Log ("Player Ship Collided");  // Use UnityEngine.Debug explicitly
            Instantiate (poofParticle, playerShip.transform.position, Quaternion.identity);

            if ( explosionSFX != null ) {
                AudioSource.PlayClipAtPoint (explosionSFX, Camera.main.transform.position);
            }

            collision.collider.GetComponent<PlayerShip> ().TakeDamage (); // Call TakeDamage() on the player ship
            Destroy (gameObject); // Destroy the asteroid

            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
        }
    }

    public void TakeDamage()
    {
        transform.localScale -= new Vector3 (0.3f, 0.4f, 0);

        if ( transform.localScale.y < 0.1f ) {

            if ( explosionSFX != null ) {
                AudioSource.PlayClipAtPoint (explosionSFX, Camera.main.transform.position);
            }

            if ( GameSession.Instance != null ) {
                GameSession.Instance.AddScores (scoreValue);  
            } else {
                UnityEngine.Debug.Log ("GameSession instance is missing!");
            }

            Destroy (gameObject);
        }
    }


    void Start()
    {

    }

    void Update()
    {

    }
}
