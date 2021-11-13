using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class PlayerControls : MonoBehaviour
{
    public float speed = 3;
    public float jumpPower = 10;

    Rigidbody2D rb;
    Adrenaline adr; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        adr = GetComponentInChildren<Adrenaline>();
    }
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        //rb.velocity.x = speed * horizontalMovement;//not allowed
        rb.velocity = new Vector2(speed * horizontalMovement, rb.velocity.y);
        bool isJumping = Input.GetAxis("Jump") > 0;

       
        //Jump Method 3: Correct way.
        if (isJumping)//if pressing the spacebar/trying to jump
        {
            
            //Check if the feet are colliding with something right now
            Vector3 feetPosition = transform.GetChild(0).position;
            
            Collider2D[] colliders = Physics2D.OverlapCircleAll(feetPosition, .25f);
            
            for (int i = 0; i < colliders.Length; ++i)
            {
                if (colliders[i].gameObject == gameObject || colliders[i].gameObject.name == "AdrenalineCollider")
                {
                    continue;
                }
                //make each jump consistently the same speed/height
                
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpPower);
                
                break;
            }
        }
    }
    
}
