using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject poofParticle;
    [SerializeField] Transform shipFirePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate(bulletPrefab, shipFirePoint.position, Quaternion.identity);

        if (renderer.isVisible)
        {
            Debug.Log("Enemy Ship Visible");
            StartCoroutine(StartFiring());
        }
        
    }

    IEnumerator StartFiring()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(bulletPrefab, shipFirePoint.position, shipFirePoint.rotation);
    }

    public void TakeDamage()
    {
        Destroy(gameObject);

        //if ( GameSession.Instance != null ) {
        //    GameSession.Instance.AddScores (enemyScoreValue);  // Cộng 200 điểm
        //}

        //// Tạo hiệu ứng nổ và xóa kẻ địch
        //Instantiate (poofParticle, transform.position, Quaternion.identity);
        //Destroy (gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PlayerShip>())
        {
            Debug.Log("Player Ship Collided with Enemy Ship");
            Instantiate(poofParticle, playerShip.transform.position, Quaternion.identity);
            Destroy(playerShip);
            Destroy(gameObject);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
