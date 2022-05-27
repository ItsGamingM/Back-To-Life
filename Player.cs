using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] Vector2 deathKick = new Vector2 (10f,10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform FirePoint;

    Vector2 movingInput;
    Rigidbody2D rb;
    Animator animator;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;
    float gravityScaleAtStart;

    bool isAlive = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = rb.gravityScale;
        feetCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!isAlive) {return;}
        Run();
        Flip();
        Die();
    }
    void OnFire (InputValue value)
    {
        if (!isAlive) {return;}
        Instantiate (bullet, FirePoint.position, transform.rotation);

    }

     void OnMove (InputValue value)
    {   
        if (!isAlive) {return;}
        movingInput = value.Get<Vector2>();        
    }



    void OnJump (InputValue value)
    {
        if (!isAlive) {return;}
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (value.isPressed)
        {
            rb.velocity += new Vector2 (rb.velocity.x, jumpSpeed);
        }    
       
    }


        void Run ()
    {
        Vector2 playerVelocity = new Vector2 (movingInput.x * speed, rb.velocity.y);
        rb.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        
        animator.SetBool("run", playerHasHorizontalSpeed);
      
    }

 
    void Flip()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x), 1f);
        }

    }

    void Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            animator.SetTrigger("isDead");

            rb.velocity = deathKick;
           FindObjectOfType<GameSession>().ProcessPlayerDeath();

        }
    }

    
}
