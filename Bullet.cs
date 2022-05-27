using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float bulletSpeed = 10f;
    Rigidbody2D myRigidBody;
    Player player;
    float xSpeed;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }


    void Update()
    {
        myRigidBody.velocity = new Vector2 (xSpeed,0f);
        transform.localScale = new Vector2 ((Mathf.Sign(myRigidBody.velocity.x)), 1f);

    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }    
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy (gameObject);
    }

}
