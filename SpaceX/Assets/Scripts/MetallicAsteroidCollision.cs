using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetallicAsteroidCollision : MonoBehaviour
{
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject poofParticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PlayerShip>())
        {
            Debug.Log("Player Ship Collided");
            Instantiate(poofParticle, playerShip.transform.position, Quaternion.identity);
            Destroy(playerShip);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
