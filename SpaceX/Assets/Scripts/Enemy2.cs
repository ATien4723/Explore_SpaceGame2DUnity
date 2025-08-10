using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] GameObject poofParticle; // Hiệu ứng nổ
    [SerializeField] Transform shipFirePoint;  // Điểm bắn
    [SerializeField] GameObject bulletPrefab;   // Đạn
    [SerializeField] float moveSpeed = 2f;      // Tốc độ di chuyển
    [SerializeField] float moveRange = 5f;      // Giới hạn di chuyển
    [SerializeField] float leftLimit;            // Giới hạn bên trái
    [SerializeField] float rightLimit;           // Giới hạn bên phải

    private bool movingRight = true;             // Hướng di chuyển

    void Start()
    {
        leftLimit = transform.position.x - moveRange;
        rightLimit = transform.position.x + moveRange;
    }

    void Update()
    {
        MoveLeftRight ();
    }

    void MoveLeftRight()
    {
        // Di chuyển enemy trái phải trong giới hạn
        if ( movingRight ) {
            transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
            if ( transform.position.x >= rightLimit ) {
                movingRight = false; // Đổi hướng
            }
        } else {
            transform.Translate (Vector2.left * moveSpeed * Time.deltaTime);
            if ( transform.position.x <= leftLimit ) {
                movingRight = true; // Đổi hướng
            }
        }
    }



    IEnumerator StartFiring()
    {
        while ( true ) // Thay đổi để bắn liên tục
        {
            yield return new WaitForSeconds (1f); // Thời gian chờ giữa các lần bắn
            Instantiate (bulletPrefab, shipFirePoint.position, shipFirePoint.rotation); // Tạo đạn
        }
    }

    public void TakeDamage()
    {
        Destroy (gameObject); // Hủy enemy
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với PlayerShip
        if ( collision.collider.GetComponent<PlayerShip> () ) {
            Instantiate (poofParticle, transform.position, Quaternion.identity); // Tạo hiệu ứng nổ tại vị trí của enemy
            Destroy (collision.collider.gameObject); // Hủy tàu của người chơi
            Destroy (gameObject); // Hủy enemy

            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); // Quay lại màn chơi
        }
    }
}


