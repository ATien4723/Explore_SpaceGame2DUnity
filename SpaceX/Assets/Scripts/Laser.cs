using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] Transform shipFirePoint;
    //[SerializeField] float hitReductionRate = 0.3f;
    [SerializeField] GameObject bulletPrefab;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            Debug.Log("Firing");
        }
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, shipFirePoint.position, Quaternion.identity);
    }

    //private void Fire()
    //{
    //    RaycastHit2D hitInfo = Physics2D.Raycast(shipFirePoint.position, shipFirePoint.right);

    //    if (hitInfo)
    //    {
    //        AsteroidCollision asteroid = hitInfo.transform.GetComponent<AsteroidCollision>();
    //        EnemyShip enemy = hitInfo.transform.GetComponent<EnemyShip>();
    //        if (asteroid != null)
    //        {
    //            Debug.Log("Asteroid Hit");
    //            Instantiate(poofParticle, hitInfo.point, Quaternion.identity);
    //            asteroid.TakeDamage();
    //        }
    //        else if (enemy != null)
    //        {
    //            Debug.Log("Enemy hit");
    //            Instantiate(poofParticle, hitInfo.point, Quaternion.identity);
    //            enemy.TakeDamage();
    //        }
    //    }
    //}
}
