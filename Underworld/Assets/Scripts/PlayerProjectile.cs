using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 50.0f;
    public float damage = -20f;
    public GameObject explosion;
    Animator anim; 
    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.AddForce(Vector2.right * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Spawner")
        {
            Vector3 middle = collision.transform.position ;
            Instantiate(explosion, middle + (Vector3.left * 0.5f), transform.rotation);
            collision.gameObject.GetComponent<Spawner>().currentHealth += damage;
            
            if (collision.gameObject.GetComponent<Spawner>().currentHealth <= 0)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }else if(collision.gameObject.tag == "BadProj")
        {
            Vector3 middle = (transform.position / 2) + (collision.transform.position / 2) / 2;
            Instantiate(explosion, middle, transform.rotation);
        }else if(collision.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }

    }
}
