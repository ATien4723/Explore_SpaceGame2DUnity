using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    public new Transform camera;
    [SerializeField] LevelController levelController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Finish Level");

        if (other.name == "PlayerShip")
        {
            //Vector3 currentCameraPosition = camera.position;
            //camera.position = currentCameraPosition;
            //Debug.Log(currentCameraPosition.x.ToString() + " " + currentCameraPosition.y.ToString() + " " + currentCameraPosition.z.ToString());

            levelController.CompleteLevel();
            
        }
        
    }

}
