using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses the right control key, the player will shoot a bullet
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
    }
}
