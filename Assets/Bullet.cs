using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
      void Update()
    {
        // Check if the bullet is off-screen
        if (IsOffScreen())
        {
            Destroy(gameObject);
        }
    }

    private bool IsOffScreen()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        
        return viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1;
    }
}
