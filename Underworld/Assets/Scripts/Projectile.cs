using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Projectile : MonoBehaviour
{
    Slider adrSlide;

    public float adrDivide = 1.5f;
    public int damage = 10;
    public int speedPerSec = 3;
    
    public GameObject targetObject;
    public Vector3 targetPosition;
    public Transform targetTransform;
    public Vector3 directionVector;

    void Start()
    {
       adrSlide = Camera.main.GetComponentInChildren<Slider>();
        if (targetTransform == null)
            targetTransform = FindObjectOfType<PlayerControls>().transform;
        if (targetObject == null)
            targetObject = FindObjectOfType<PlayerControls>().gameObject;
        targetPosition = targetObject.transform.position;
       directionVector =
            targetPosition - transform.position;
    }
    
    private void FixedUpdate()
    {
        directionVector.Normalize();
        transform.position += directionVector * speedPerSec * Time.deltaTime;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerControls>().isInvincible)
            {
                if (gameObject.tag == "Health")
                {
                    collision.gameObject.GetComponentInChildren<Slider>().value += damage;
                    Destroy(gameObject);
                }else
                {
                    adrSlide.value /= 2f;
                    Destroy(gameObject);
                }
            }else
            {
                if (gameObject.tag == "Health")
                {
                    Destroy(gameObject);
                    collision.gameObject.GetComponentInChildren<Slider>().value += damage;
                }else
                {
                    collision.gameObject.GetComponent<PlayerControls>().becomeInvincible();
                    Destroy(gameObject);
                    collision.gameObject.GetComponentInChildren<Slider>().value -= damage;
                    adrSlide.value /= 2f;
                }
            }
        }
        else if(collision.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }else if(collision.gameObject.tag == "PlayProj")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }
    
}


