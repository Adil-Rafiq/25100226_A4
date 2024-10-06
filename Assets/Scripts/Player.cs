using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    
    [Header("Player Movement")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 18f;
    private bool  grounded;
  
    private bool facingRight = true;
    private float movingInput;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movingInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movingInput * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
           Jump();
        }

        if (movingInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (movingInput < 0 && facingRight)
        {
            Flip();
        }

       AnimatorController();
    }

    private void FixedUpdate() {
        
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void AnimatorController()
    {
        anim.SetBool("isMoving", movingInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
