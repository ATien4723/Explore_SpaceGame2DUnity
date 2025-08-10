using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointPerCoin = 1000;
    bool wasCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "PlayerShip" && !wasCollected ) {
            wasCollected = true;  // Đánh dấu rằng đồng xu đã được nhặt

            FindObjectOfType<GameSession> ().AddScores (pointPerCoin);

            if ( coinPickupSFX != null ) {
                AudioSource.PlayClipAtPoint (coinPickupSFX, Camera.main.transform.position);
            }

            Destroy (gameObject);
        }
    }
}
